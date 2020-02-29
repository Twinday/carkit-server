using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using Carkit.Data.Specification;
using Carkit.Services.DtoModels;
using Carkit.Services.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        Task<List<string>> GetFreeTime(int repairShopId/*, List<int> detailIds*/);
    }

    /// <summary>
    /// Сервис автомастерских.
    /// </summary>
    public class RepairShopService : BaseService<RepairShop, RepairShopDto>, IRepairShopService
    {
        private readonly ITimeService _timeService;

        public RepairShopService(IUnitOfWork unitOfWork, IMapper mapper, ITimeService timeService) : base(unitOfWork, mapper)
        {
            _timeService = timeService;
        }

        public async Task<List<string>> GetFreeTime(int repairShopId/*, List<int> detailIds*/)
        {
            var repairShop = (await _repository.GetAsync(x => x.Id == repairShopId)).Items?.FirstOrDefault();

            return _timeService.GetPeriodForDay(repairShop.Orders);
        }

        private async Task GetBusyTime()
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
