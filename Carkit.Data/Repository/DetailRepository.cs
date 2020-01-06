using Carkit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
    internal class DetailRepository : Repository<Detail>
    {
        public DetailRepository(DbContext context) : base(context)
        {
        }

        public override Task<Detail> GetByIDAsync(object id)
        {
            return IncludeQueryable(dbSet)
                .FirstOrDefaultAsync(itm => Equals(itm.Id, id));
        }

        protected override IQueryable<Detail> IncludeQueryable(IQueryable<Detail> query)
        {
            return query
                .Include(q => q.Producer);
        }
    }
}
