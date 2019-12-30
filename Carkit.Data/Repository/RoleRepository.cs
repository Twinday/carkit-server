using Carkit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Data.Repository
{
    internal class RoleRepository : Repository<Role>
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        public override Task<Role> GetByIDAsync(object id)
        {
            return IncludeQueryable(dbSet)
                .FirstOrDefaultAsync(itm => Equals(itm.Id, id));
        }

        protected override IQueryable<Role> IncludeQueryable(IQueryable<Role> query)
        {
            return query;
        }
    }
}
