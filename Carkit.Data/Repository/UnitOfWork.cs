using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Repository
{
    public class UnitOfWork : UnitOfWorkBase<CarkitContext>
    {
        public UnitOfWork(CarkitContext context) : base(context)
        {
        }

        protected override IRepository<TEntity> GetRepositoryInstance<TEntity>()
        {
            if (typeof(TEntity) == typeof(Role))
                return ((IRepository<TEntity>)new RoleRepository(_context));

            /*if (typeof(TEntity) == typeof(Material))
                return ((IRepository<TEntity>)new MaterialRepository(_context));

            if (typeof(TEntity) == typeof(Company))
                return ((IRepository<TEntity>)new CompanyRepository(_context));

            if (typeof(TEntity) == typeof(Warehouse))
                return ((IRepository<TEntity>)new WarehouseRepository(_context));

            if (typeof(TEntity) == typeof(Person))
                return ((IRepository<TEntity>)new PersonRepository(_context));*/

            return base.GetRepositoryInstance<TEntity>();
        }
    }
}
