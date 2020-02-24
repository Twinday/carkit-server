using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.Services
{
    public interface ICarCardService : IBaseService<CarCard, int>
    {
    }

    public class CarCardService : BaseService<CarCard>, ICarCardService
    {
        public CarCardService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
