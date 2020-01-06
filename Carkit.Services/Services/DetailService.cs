using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using Carkit.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Services.Services
{
    public interface IDetailService : IBaseService<Detail, DetailDto, int>
    {
    }

    public class DetailService : BaseService<Detail, DetailDto>, IDetailService
    {
        public DetailService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<int> AddAsync(DetailDto item)
        {
            var domainItem = _mapper.Map<Detail>(item);

            domainItem.Producer = await AddOrGet(domainItem.Producer);

            _repository.Insert(domainItem);
            await _unitOfWork.SaveAsync();
            return domainItem.Id;
        }

    }
}
