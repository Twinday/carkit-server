using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using Carkit.Services.DtoModels;
using Carkit.Services.DtoModels.Work;
using Carkit.Services.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Services.Services
{
    public interface IWorkService : IBaseService<Work, WorkDto, int>
    {
        Task<WorkSearchResult> GetLinkedDetailsForModelCar(SearchResult<WorkListView> searchResult, WorkSearchData search);
    }

    public class WorkService : BaseService<Work, WorkDto>, IWorkService
    {
        public WorkService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Возвращает модель работ для заказа.
        /// </summary>
        /// <param name="searchResult">Результат поиска.</param>
        /// <param name="search">Параметры для маппинга в модель для заказа.</param>
        /// <returns></returns>
        public async Task<WorkSearchResult> GetLinkedDetailsForModelCar(SearchResult<WorkListView> searchResult, WorkSearchData search)
        {
            searchResult.Items.ForEach(q => q.Details.ForEach(s => s.ModelCarIds.Where(w => w == search.ModelCarId)));

            var workForCarRepository = _unitOfWork.GetRepository<WorkForCar>();
            var worksForCar = (await workForCarRepository.GetAsync(q => q.CarCard != null && q.CarCard.ModelCarId == search.ModelCarId 
                && q.Kilometrage <= search.Kilometrage)).Items.LastOrDefault();

            var recomendedWorks = new List<WorkListView>();
            var otherWorks = new List<WorkListView>();
            foreach (var work in searchResult.Items)
            {
                if (worksForCar.RecomendedWorks.Any(q => q.Id == work.Id))
                    recomendedWorks.Add(work);
                else
                    otherWorks.Add(work);
            }

            return new WorkSearchResult
            {
                TotalCount = searchResult.TotalCount,
                WorksForCar = recomendedWorks,
                OtherWorks = otherWorks
            };
        }

        public override async Task UpdateAsync(WorkDto item)
        {
            var domainItem = _mapper.Map<Work>(item);

            await UpdateDependsObjects(domainItem.WorkEfforts, o => !o.IsDeleted && o.WorkId == domainItem.Id);

            _repository.Update(domainItem);
            await _unitOfWork.SaveAsync();
        }

        public override async Task<int> AddAsync(WorkDto item)
        {
            var domainItem = _mapper.Map<Work>(item);

            AddDependsObjects(domainItem.WorkEfforts);

            _repository.Insert(domainItem);
            await _unitOfWork.SaveAsync();
            return domainItem.Id;
        }

    }
}
