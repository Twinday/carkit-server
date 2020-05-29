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
    public interface ICarCardService : IBaseService<CarCard, int>
    {
        Task<CarCardView> ParseVIN(string vin);
    }

    public class CarCardService : BaseService<CarCard>, ICarCardService
    {
        private readonly IVINService _vinService;

        public CarCardService(IUnitOfWork unitOfWork, IMapper mapper, IVINService vinService) : base(unitOfWork, mapper)
        {
            _vinService = vinService;
        }

        public async Task<CarCardView> ParseVIN(string vin)
        {
            var decodeVIN = await _vinService.GetCar(vin);

            var producerRepository = _unitOfWork.GetRepository<Producer>();
            var modelCarRepository = _unitOfWork.GetRepository<ModelCar>();

            var producer = (await producerRepository.GetAsync(x => x.Name == decodeVIN.Make)).Items.FirstOrDefault();
            var model = (await modelCarRepository.GetAsync(x => x.Name == decodeVIN.Model)).Items.FirstOrDefault();

            if (producer == null)
            {
                producer = new Producer { Name = decodeVIN.Make, County = decodeVIN.PlantCountry };
                producerRepository.Insert(producer);
            }
            if (model == null)
            {
                model = new ModelCar { Name = decodeVIN.Model, ProducerId = producer.Id };
                modelCarRepository.Insert(model);
            }

            var carCard = new CarCard { ModelCarId = model.Id, Year = int.Parse(decodeVIN.ModelYear) };
            _repository.Insert(carCard);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<CarCardView>(carCard);
        }
    }
}
