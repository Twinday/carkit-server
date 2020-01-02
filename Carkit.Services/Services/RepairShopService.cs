using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using Carkit.Data.Specification;
using Carkit.Services.DtoModels;
using Carkit.Services.SearchModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Services.Services
{
    /// <summary>
    /// Интерфейс сервиса автомастерскиих.
    /// </summary>
    public interface IRepairShopService : IBaseService<RepairShop, RepairShopDto, int>
    {
        Task<bool> CanAdd(RepairShopDto item);
    }

    /// <summary>
    /// Сервис автомастерских.
    /// </summary>
    public class RepairShopService : BaseService<RepairShop, RepairShopDto>, IRepairShopService
    {
        public RepairShopService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> CanAdd(RepairShopDto item)
        {
            return await _repository.CountAsync(q => q.Address == item.Address) > 0 ? false : true;
        }

        protected override Specification<RepairShop> GetSpecification(SearchData search)
        {
            return base.GetSpecification(search) && RepairShop.FindByText(search.SearchText);
        }
    }
}
