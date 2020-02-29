using Carkit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
    internal class RepairShopRepository : Repository<RepairShop>
    {
        public RepairShopRepository(DbContext context) : base(context)
        {
        }

        public override Task<RepairShop> GetByIDAsync(object id)
        {
            return IncludeQueryable(dbSet)
                .FirstOrDefaultAsync(itm => Equals(itm.Id, id));
        }

        protected override IQueryable<RepairShop> IncludeQueryable(IQueryable<RepairShop> query)
        {
            return query
                .Include(q => q.Orders);
        }
    }
}
