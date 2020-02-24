using Carkit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
    internal class CarCardRepository : Repository<CarCard>
    {
        public CarCardRepository(DbContext context) : base(context)
        {
        }

        public override Task<CarCard> GetByIDAsync(object id)
        {
            return IncludeQueryable(dbSet)
                .FirstOrDefaultAsync(itm => Equals(itm.Id, id));
        }

        protected override IQueryable<CarCard> IncludeQueryable(IQueryable<CarCard> query)
        {
            return query
                .Include(q => q.Model)
                    .ThenInclude(q => q.Producer);
        }
    }
}
