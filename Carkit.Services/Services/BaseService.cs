using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using Carkit.Data.Specification;
using Carkit.Services.Helpers.Order;
using Carkit.Services.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Services.Services
{
	public class BaseService<TEntity> : IService<TEntity> where TEntity : BaseModel
	{
		protected IUnitOfWork _unitOfWork;
		protected readonly IMapper _mapper;
		//protected readonly ICurrentUserService _currentUserService;
		protected readonly IRepository<TEntity> _repository;
		protected readonly OrderHelper<TEntity> _orderService;

		public BaseService(IUnitOfWork unitOfWork, IMapper mapper/*, ICurrentUserService currentUserService*/)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			//this._currentUserService = currentUserService;
			_repository = _unitOfWork.GetRepository<TEntity>();
			_orderService = new OrderHelper<TEntity>(mapper);
		}

		public virtual async Task<int> AddAsync<TDtoEntity>(TDtoEntity item)
		{
			TEntity domainItem = _mapper.Map<TEntity>(item);
			_repository.Insert(domainItem);
			await _unitOfWork.SaveAsync();
			return domainItem.Id;
		}

		public virtual async Task<IEnumerable<int>> AddAsync<TDtoEntity>(IEnumerable<TDtoEntity> items)
		{
			IEnumerable<TEntity> domainItems = _mapper.Map<IEnumerable<TEntity>>(items);

			_repository.Insert(domainItems);
			await _unitOfWork.SaveAsync();

			return domainItems.Select(v => v.Id);
		}

		public virtual async Task DeleteAsync(int id)
		{
			TEntity item = await _repository.GetByIDAsync(id);
			//item.IsDeleted = true;
			_repository.Delete(item);
			await _unitOfWork.SaveAsync();
		}

		public virtual Task<bool> Exists(int id)
		{
			return _repository.Exists(b => b.Id == id);
		}

		public virtual async Task<TDtoEntity> GetByIdAsync<TDtoEntity>(int id)
		{
			TEntity item = await _repository.GetByIDAsync(id);
			return _mapper.Map<TDtoEntity>(item);
		}

		public virtual async Task<SearchResult<TDtoEntity>> SearchAsync<TDtoEntity>(SearchData search)
		{
			var (items, totalCount) =
				await _repository.GetAsync(
					GetSpecification(search),
					_orderService.GetOrderExpression<TDtoEntity>(search.Order),
					search.PageNumber,
					search.PageSize,
					search.GetTotalCount);

			return new SearchResult<TDtoEntity> { Items = _mapper.Map<List<TDtoEntity>>(items), TotalCount = totalCount };
		}

		protected virtual Specification<TEntity> GetSpecification(SearchData search)
		{
			return BaseModel.FindByDeleteFlag<TEntity>();
		}

		public virtual async Task UpdateAsync<TDtoEntity>(TDtoEntity item)
		{
			var domainItem = _mapper.Map<TEntity>(item);
			_repository.Update(domainItem);
			await _unitOfWork.SaveAsync();
		}

		/// <summary>
		/// Обновление зависимых сущностей при обновлении главной.
		/// </summary>
		/// <param name="dependObjects">Зависимые сущности для обновлеения.</param>
		/// <param name="predicate">Предикат поиска старых зависимых сущностей.</param>
		/// <returns></returns>
		protected virtual async Task UpdateDependsObjects<TDependEntity>(List<TDependEntity> dependObjects, Expression<Func<TDependEntity, bool>> predicate)
			where TDependEntity : BaseModel
		{
			var repository = _unitOfWork.GetRepository<TDependEntity>();
			var (oldObjects, _) = await repository.GetAsync(predicate);

			var deletedObjects = oldObjects
				.Where(o => !dependObjects.Any(i => i.Id == o.Id))
				.ToList();

			var updatedObjects = dependObjects
				.Where(o => oldObjects.Any(i => i.Id == o.Id))
				.ToList();

			var addedObjects = dependObjects
				.Where(o => !oldObjects.Any(i => i.Id == o.Id))
				.ToList();

			repository.Insert(addedObjects);
		}

		/// <summary>
		/// Добавление зависимых сущностей при создании главной сущности.
		/// </summary>
		/// <typeparam name="dependObjects">Сущности для добавления.</typeparam>
		protected virtual void AddDependsObjects<TDependEntity>(List<TDependEntity> dependObjects)
			where TDependEntity : BaseModel
		{
			var repository = _unitOfWork.GetRepository<TDependEntity>();
			repository.Insert(dependObjects);
		}

		/// <summary>
		/// Обновление отдельных полей сущности.
		/// </summary>
		/// <typeparam name="TDtoEntity">Тип модели для обновления сущности.</typeparam>
		/// <param name="id">Идентификатор обновляемой сущности.</param>
		/// <param name="patchData">Структура данных, </param>
		/// <returns><see cref="Task"/> с ассинхронным действием обновления.</returns>
		public virtual async Task UpdateAsync<TDtoEntity>(int id, UpdateData patchData)
		{
			var (items, _) = await _repository.GetAsync(BaseModel.FindById<TEntity>(id));
			TEntity domainItem = items.FirstOrDefault();

			TDtoEntity dtoEntity = _mapper.Map<TDtoEntity>(domainItem);

			var dtoType = typeof(TDtoEntity);
			foreach (var updatingProperty in patchData.Fields)
			{
				var property = dtoType.GetProperty(updatingProperty.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
				if (property != null)
				{
					var setValue = Convert.ChangeType(updatingProperty.Value, property.PropertyType);
					property.SetValue(dtoEntity, setValue);
				}
			}

			_mapper.Map(dtoEntity, domainItem);
			_repository.Update(domainItem);
			await _unitOfWork.SaveAsync();
		}

		/// <summary>
		/// Добавляет сущность, если она отсутствует в БД.
		/// </summary>
		/// <typeparam name="T">Тип сущности.</typeparam>
		/// <param name="entity">Добавляемая сущность.</param>
		/// <returns>Если в БД уже есть сущность с таким же идентификатором, то возвращает эту сущность. Иначе - возвращает добавленную сущность.</returns>
		public virtual async Task<TDomainEntity> AddOrGet<TDomainEntity>(TDomainEntity entity) where TDomainEntity : BaseModel
		{
			if (entity == null)
			{
				return null;
			}

			var repository = _unitOfWork.GetRepository<TDomainEntity>();
			var savedModel = await repository.GetByIDAsync(entity.Id);

			if (savedModel == null)
			{
				repository.Insert(entity);

			}

			return savedModel ?? entity;
		}
		#region Группа методов для работы со связанными сущностями в новой парадигме удаления объектов.
		/// <summary>
		/// Добавление зависимых сущностей при создании главной сущности.
		/// </summary>
		/// <typeparam name="dependObjects">Сущности для добавления.</typeparam>
		protected virtual void AddDepends<TDependEntity>(List<TDependEntity> dependObjects)
			where TDependEntity : BaseModel
		{
			var repository = _unitOfWork.GetRepository<TDependEntity>();
			repository.Insert(dependObjects);
		}

		/// <summary>
		/// Обновление зависимых сущностей при обновлении главной.
		/// Новые объекты из списка добавляются в репозиторий.
		/// Исключённые из списка объекты, удаляются.
		/// </summary>
		/// <param name="dependObjects">Зависимые сущности для обновлеения.</param>
		/// <param name="predicate">Предикат поиска старых зависимых сущностей.</param>
		/// <returns></returns>
		protected virtual async Task UpdateDepends<TDependEntity>(List<TDependEntity> dependObjects, Expression<Func<TDependEntity, bool>> predicate)
			where TDependEntity : BaseModel
		{
			var repository = _unitOfWork.GetRepository<TDependEntity>();

			var (oldObjects, _) = await repository.GetAsync(predicate);

			var deletedObjects = oldObjects
				.Where(o => !dependObjects.Any(i => i.Id == o.Id))
				.ToList();

			var updatedObjects = dependObjects
				.Where(o => oldObjects.Any(i => i.Id == o.Id))
				.ToList();

			var addedObjects = dependObjects
				.Where(o => !oldObjects.Any(i => i.Id == o.Id))
				.ToList();

			repository.Update(updatedObjects);
			repository.Delete(deletedObjects);
			repository.Insert(addedObjects);
		}

		/// <summary>
		/// Удаление зависимых сущностей.
		/// </summary>
		/// <typeparam name="dependObjects">Сущности для удаления.</typeparam>
		protected virtual void DeleteDepends<TDependEntity>(List<TDependEntity> dependObjects)
			where TDependEntity : BaseModel
		{
			var repository = _unitOfWork.GetRepository<TDependEntity>();
			repository.Delete(dependObjects);
		}
		#endregion
	}

	public class BaseService<TEntity, TEditDto> : BaseService<TEntity>, IBaseService<TEntity, TEditDto, int> where TEntity : BaseModel
	{
		public BaseService(IUnitOfWork unitOfWork, IMapper mapper/*, ICurrentUserService currentUserService*/) : base(unitOfWork, mapper/*, currentUserService*/)
		{
		}

		public virtual Task<int> AddAsync(TEditDto item)
		{
			return base.AddAsync(item);
		}

		public virtual Task<IEnumerable<int>> AddAsync(IEnumerable<TEditDto> items)
		{
			return base.AddAsync(items);
		}


		public virtual Task<TEditDto> GetByIdAsync(int id)
		{
			return base.GetByIdAsync<TEditDto>(id);
		}

		public virtual Task UpdateAsync(TEditDto item)
		{
			return base.UpdateAsync(item);
		}


		/// <summary>
		/// Обновление отдельных полей сущности.
		/// </summary>
		/// <param name="id">Идентификатор обновляемой сущности.</param>
		/// <param name="patchData">Структура данных, </param>
		/// <returns><see cref="Task"/> с ассинхронным действием обновления.</returns>
		public virtual Task UpdateAsync(int id, UpdateData patchData)
		{
			return base.UpdateAsync<TEditDto>(id, patchData);
		}
	}
}
