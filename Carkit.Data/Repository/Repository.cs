using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected DbContext context;
		internal protected DbSet<TEntity> dbSet;

		public Repository(DbContext context)
		{
			this.context = context;
			dbSet = context.Set<TEntity>();
		}

		public virtual (IEnumerable<TEntity> Items, int TotalCount) Get(
			Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			int pageIndex = 0,
			int pageSize = 0,
			bool requiredTotalCount = false)
		{
			IQueryable<TEntity> query = IncludeQueryable(dbSet);
			return InternalGet(query, predicate, orderBy, pageIndex, pageSize, requiredTotalCount);
		}

		public virtual (IEnumerable<TEntity> Items, int TotalCount) Get(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			int pageIndex = 0,
			int pageSize = 0,
			bool requiredTotalCount = false)
		{
			return Get(null, orderBy, pageIndex, pageSize, requiredTotalCount);
		}

		public virtual Task<(List<TEntity> Items, int TotalCount)> GetAsync(
			Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			int pageIndex = 0,
			int pageSize = 0,
			bool requiredTotalCount = false,
			bool ignoredFilters = false)
		{
			IQueryable<TEntity> query = IncludeQueryable(dbSet);
			if (ignoredFilters)
			{
				query = query.IgnoreQueryFilters();
			}

			return InternalGetAsync(query, predicate, orderBy, pageIndex, pageSize, requiredTotalCount);
		}

		public virtual Task<(List<TEntity> Items, int TotalCount)> GetAsync(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			int pageIndex = 0,
			int pageSize = 0,
			bool requiredTotalCount = false)
		{
			return GetAsync(null, orderBy, pageIndex, pageSize, requiredTotalCount);
		}

		public virtual Task<TEntity> GetByIDAsync(object id)
		{
			return dbSet.FindAsync(id);
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public virtual void Delete(IEnumerable<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				Delete(entity);
			}
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public virtual void Update(IEnumerable<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				Update(entity);
			}
		}

		public virtual Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
		{
			return dbSet.AnyAsync(predicate);
		}

		protected virtual (IEnumerable<TEntity> Items, int TotalCount) InternalGet(
			IQueryable<TEntity> query,
		Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			int pageIndex,
			int pageSize,
			bool requiredTotalCount)
		{
			query = PrepareQuery(query, predicate, orderBy, pageIndex, pageSize);
			int totalCount = 0;
			if (requiredTotalCount)
			{
				var totalCountQuery = PrepareQuery(query, predicate);
				totalCount = totalCountQuery.Count();
			}

			return (Items: query.AsNoTracking().ToList(), TotalCount: totalCount);
		}

		protected virtual async Task<(List<TEntity> Items, int TotalCount)> InternalGetAsync(
			IQueryable<TEntity> query,
		Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			int pageIndex,
			int pageSize,
			bool requiredTotalCount)
		{
			int totalCount = 0;
			if (requiredTotalCount)
			{
				var totalCountQuery = PrepareQuery(query, predicate);
				totalCount = await totalCountQuery.CountAsync();
			}

			query = PrepareQuery(query, predicate, orderBy, pageIndex, pageSize);

			return (Items: await query.AsNoTracking().ToListAsync(), TotalCount: totalCount);
		}

		protected virtual IQueryable<TEntity> PrepareQuery(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int pageIndex = 0, int pageSize = 0)
		{
			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			if (pageIndex != 0 || pageSize != 0)
			{
				query = query.Skip(pageIndex * pageSize).Take(pageSize);
			}

			return query;
		}

		public void Insert(IEnumerable<TEntity> entities)
		{
			dbSet.AddRange(entities);
		}

		/// <summary>
		/// Подключает связанные сущности через Include.
		/// </summary>
		/// <param name="query">Исходный запрос.</param>
		/// <returns>Измененный запрос.</returns>
		protected virtual IQueryable<TEntity> IncludeQueryable(IQueryable<TEntity> query)
		{
			return query;
		}

		public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return dbSet.CountAsync(predicate);
		}
	}
}
