using Carkit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
    class WorkRepository : Repository<Work>
    {
        public WorkRepository(DbContext context) : base(context)
        {
        }

        public override Task<Work> GetByIDAsync(object id)
        {
            return IncludeQueryable(dbSet)
                .FirstOrDefaultAsync(itm => Equals(itm.Id, id));
        }

        protected override IQueryable<Work> IncludeQueryable(IQueryable<Work> query)
        {
            return query
                .Include(q => q.Details)
                .Include(q => q.WorkEfforts);
        }
    }
}
