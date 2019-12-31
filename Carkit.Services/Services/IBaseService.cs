using Carkit.Data.Models;
using Carkit.Services.SearchModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carkit.Services.Services
{
    public interface IBaseService<TEntity, TEditDto, TId> where TEntity : BaseModel
    {
        Task<TId> AddAsync(TEditDto item);
        Task<IEnumerable<TId>> AddAsync(IEnumerable<TEditDto> items);
        Task UpdateAsync(TEditDto item);
        Task UpdateAsync(TId id, UpdateData patchData);
        Task DeleteAsync(TId id);
        Task<SearchResult<TDtoEntity>> SearchAsync<TDtoEntity>(SearchData search);
        Task<TDtoEntity> GetByIdAsync<TDtoEntity>(TId id);
        Task<TEditDto> GetByIdAsync(TId id);
        Task<bool> Exists(TId id);
    }

    public interface IBaseService<TEntity, TId> where TEntity : BaseModel
    {
        Task<TId> AddAsync<TDtoEntity>(TDtoEntity item);
        Task<IEnumerable<TId>> AddAsync<TDtoEntity>(IEnumerable<TDtoEntity> items);
        Task UpdateAsync<TDtoEntity>(TDtoEntity item);
        Task UpdateAsync<TDtoEntity>(TId id, UpdateData patchData);
        Task DeleteAsync(TId id);
        Task<SearchResult<TDtoEntity>> SearchAsync<TDtoEntity>(SearchData search);
        Task<TDtoEntity> GetByIdAsync<TDtoEntity>(TId id);
        Task<bool> Exists(TId id);
    }

    public interface IService<TEntity> : IBaseService<TEntity, int> where TEntity : BaseModel
    {

    }
}
