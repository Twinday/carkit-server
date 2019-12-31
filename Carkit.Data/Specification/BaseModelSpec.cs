using Carkit.Data.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    public partial class BaseModel
    {
        public static Specification<TEntity> FindByDeleteFlag<TEntity>(bool deleteFlag = false)
            where TEntity : BaseModel
        {
            return new Specification<TEntity>(v => v.IsDeleted == deleteFlag);
        }

        public static Specification<TEntity> FindById<TEntity>(int id)
            where TEntity : BaseModel
        {
            return new Specification<TEntity>(v => v.Id.Equals(id));
        }
    }
}
