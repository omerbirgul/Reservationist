using System.Linq.Expressions;

namespace App.Service.Services.GenericServices;

public interface IGenericService<TCreateRequest, TUpdateRequest, TResponse, TCreateResponse, TEntity>
    where TCreateRequest : class
    where TUpdateRequest : class
    where TResponse : class
    where TCreateResponse : class
    where TEntity : class
{
    Task<ServiceResult<List<TResponse>>> GetAllAsync();
    Task<ServiceResult<TResponse>> GetByIdAsync(int id);
    Task<ServiceResult<TCreateResponse>> CreateAsync(TCreateRequest request);
    Task<ServiceResult> UpdateAsync(int id, TUpdateRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    ServiceResult<IQueryable<TResponse>> Where(Expression<Func<TEntity, bool>> predicate);
}