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
    /// Интерфейс сервиса заказов.
    /// </summary>
    public interface IOrderService : IBaseService<Order, OrderDto, int>
    {

    }

    /// <summary>
    /// Сервис заказов.
    /// </summary>
    public class OrderService : BaseService<Order, OrderDto>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<int> AddAsync(OrderDto item)
        {
            var domainItem = _mapper.Map<Order>(item);

            AddDependsObjects(domainItem.LinkedOrderDetails);

            _repository.Insert(domainItem);
            await _unitOfWork.SaveAsync();
            return domainItem.Id;
        }

    }
}
