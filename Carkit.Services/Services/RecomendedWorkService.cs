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
    /// <summary>
    /// Интерфейс сервиса рекомендованных работ для авто с пробегом.
    /// </summary>
    public interface IRecomendedWorkService : IBaseService<WorkForCar, WorkForCarDto, int>
    {

    }

    /// <summary>
    /// Сервис рекомендованных работ для авто с пробегом.
    /// </summary>
    public class RecomendedWorkService : BaseService<WorkForCar, WorkForCarDto>, IRecomendedWorkService
    {
        public RecomendedWorkService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task UpdateAsync(WorkForCarDto item)
        {
            var domainItem = _mapper.Map<WorkForCar>(item);

            await UpdateDependsObjects(domainItem.RecomendedWorks, o => !o.IsDeleted && o.WorkForCarId == domainItem.Id);

            _repository.Update(domainItem);
            await _unitOfWork.SaveAsync();
        }

        public override async Task<int> AddAsync(WorkForCarDto item)
        {
            var domainItem = _mapper.Map<WorkForCar>(item);

            AddDependsObjects(domainItem.RecomendedWorks);

            _repository.Insert(domainItem);
            await _unitOfWork.SaveAsync();
            return domainItem.Id;
        }
    }
}
