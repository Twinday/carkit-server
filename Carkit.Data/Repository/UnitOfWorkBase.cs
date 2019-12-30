using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
    public class UnitOfWorkBase<TContext> : IUnitOfWork where TContext : DbContext
	{
		protected readonly TContext _context;

		private Dictionary<Type, object> _repositories;

		public UnitOfWorkBase(TContext context)
		{
			_context = context;
			_repositories = new Dictionary<Type, object>();
		}

		public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
		{
			object result;
			var type = typeof(TEntity);

			if (!_repositories.TryGetValue(type, out result))
			{
				result = GetRepositoryInstance<TEntity>();
				_repositories[type] = result;
			}

			return (IRepository<TEntity>)result;

		}

		protected virtual IRepository<TEntity> GetRepositoryInstance<TEntity>() where TEntity : class
		{
			return new Repository<TEntity>(_context);
		}


		public void Save()
		{
			_context.SaveChanges();
		}

		public Task SaveAsync()
		{
			return _context.SaveChangesAsync();
		}
	}
}
