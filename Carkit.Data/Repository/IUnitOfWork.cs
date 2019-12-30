using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
	public interface IUnitOfWork
	{
		IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
		void Save();
		Task SaveAsync();
	}
}
