using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using Carkit.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Services.Services
{
    public interface ICarService : IBaseService<Car, CarDto, int>
    {
    }

    public class CarService : BaseService<Car, CarDto>, ICarService
    {
        public CarService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<int> AddAsync(CarDto item)
        {
            var domainItem = (await _repository.GetAsync(x => item.VIN != null && item.VIN != string.Empty && x.VIN == item.VIN)).Items?.FirstOrDefault();

            if (domainItem != null)
            {
                return domainItem.Id;
            }

            domainItem = _mapper.Map<Car>(item);

            _repository.Insert(domainItem);
            await _unitOfWork.SaveAsync();
            return domainItem.Id;
        }
    }
}
