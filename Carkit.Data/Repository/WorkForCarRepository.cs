using Carkit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
    class WorkForCarRepository : Repository<WorkForCar>
    {
        public WorkForCarRepository(DbContext context) : base(context)
        {
        }

        public override Task<WorkForCar> GetByIDAsync(object id)
        {
            return IncludeQueryable(dbSet)
                .FirstOrDefaultAsync(itm => Equals(itm.Id, id));
        }

        protected override IQueryable<WorkForCar> IncludeQueryable(IQueryable<WorkForCar> query)
        {
            return query
                .Include(q => q.CarCard);
        }
    }
}
