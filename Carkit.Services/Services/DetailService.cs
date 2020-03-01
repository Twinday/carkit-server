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
    public interface IDetailService : IBaseService<Detail, DetailDto, int>
    {
        /// <summary>
        /// Получение периода обслуживания авто.
        /// </summary>
        /// <param name="linkedDetails">Детали для замены.</param>
        /// <param name="modelCarId">Идентификатор модели авто.</param>
        /// <returns>Время в часах.</returns>
        Task<double> GetTimePeriod(List<LinkedOrderDetailDto> linkedDetails, int modelCarId);
    }

    public class DetailService : BaseService<Detail, DetailDto>, IDetailService
    {
        public DetailService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Получение периода обслуживания авто.
        /// </summary>
        /// <param name="linkedDetails">Детали для замены.</param>
        /// <param name="modelCarId">Идентификатор модели авто.</param>
        /// <returns>Время в часах.</returns>
        public async Task<double> GetTimePeriod(List<LinkedOrderDetailDto> linkedDetails, int modelCarId)
        {
            var details = new List<Detail>();
            foreach (var detail in linkedDetails)
            {
                details.Add((await _repository.GetAsync(x => x.Id == detail.DetailId)).Items?.FirstOrDefault());
            }

            double result = 0;
            
            foreach (var detail in details)
            {
                if (detail.Work.WorkEfforts != null && detail.Work.WorkEfforts.Where(x => x.ModelCarId == modelCarId) != null)
                {
                    result += detail.Work.WorkEfforts.Where(x => x.ModelCarId == modelCarId).FirstOrDefault().Hours;
                }
                else
                {
                    result += detail.Work.Hours;
                }
            }

            return result;
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
