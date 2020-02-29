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
            if (typeof(TEntity) == typeof(Detail))
                return ((IRepository<TEntity>)new DetailRepository(_context));

            if (typeof(TEntity) == typeof(Work))
                return ((IRepository<TEntity>)new WorkRepository(_context));

            if (typeof(TEntity) == typeof(WorkForCar))
                return ((IRepository<TEntity>)new WorkForCarRepository(_context));

            if (typeof(TEntity) == typeof(CarCard))
                return ((IRepository<TEntity>)new CarCardRepository(_context));

            if (typeof(TEntity) == typeof(RepairShop))
                return ((IRepository<TEntity>)new RepairShopRepository(_context));


            return base.GetRepositoryInstance<TEntity>();
        }
    }
}
