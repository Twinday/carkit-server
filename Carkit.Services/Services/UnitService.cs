using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.Services
{
    public interface IUnitService : IBaseService<Unit, int>
    {
    }

    public class UnitService : BaseService<Unit>, IUnitService
    {
        public UnitService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
