using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

		void Delete(object id);
		void Delete(TEntity entityToDelete);
		void Delete(IEnumerable<TEntity> entities);
		(IEnumerable<TEntity> Items, int TotalCount) Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int pageIndex = 0, int pageSize = 0, bool requiredTotalCount = false);
		(IEnumerable<TEntity> Items, int TotalCount) Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int pageIndex = 0, int pageSize = 0, bool requiredTotalCount = false);
		Task<(List<TEntity> Items, int TotalCount)> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int pageIndex = 0, int pageSize = 0, bool requiredTotalCount = false, bool ignoredFilters = false);
		Task<(List<TEntity> Items, int TotalCount)> GetAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageIndex = 0, int pageSize = 0, bool requiredTotalCount = false);

		Task<TEntity> GetByIDAsync(object id);

		void Insert(IEnumerable<TEntity> entities);
		void Insert(TEntity entity);
		void Update(TEntity entityToUpdate);
		void Update(IEnumerable<TEntity> entities);
		Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
	}
}
