using AutoMapper;
using Carkit.Data.Models;
using Carkit.Data.Repository;
using Carkit.Services.DtoModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Services.Services
{
    public interface IUserService : IBaseService<User, UserDto, int>
    {
    }

    public class UserService : BaseService<User, UserDto>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<int> AddAsync(UserDto item)
        {
            var domainItem = (await _repository.GetAsync(x => x.Phone == item.Phone)).Items?.FirstOrDefault();

            if (domainItem != null)
            {
                return domainItem.Id;
            }

            domainItem = _mapper.Map<User>(item);

            _repository.Insert(domainItem);
            await _unitOfWork.SaveAsync();
            return domainItem.Id;
        }
    }
}
