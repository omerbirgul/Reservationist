using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using App.Repository.Entities.Abstract;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Service.Services.GenericServices;

public class GenericService<TCreateRequest, TUpdateRequest, TResponse, TEntity>
    : IGenericService<TCreateRequest, TUpdateRequest, TResponse, TEntity>
    where TCreateRequest : class
    where TUpdateRequest : class
    where TResponse : class
    where TEntity : class
{

    protected readonly IGenericRepository<TEntity> _genericRepository;
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;

    public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public virtual async Task<ServiceResult<List<TResponse>>> GetAllAsync()
    {
        IQueryable<TEntity> query = _genericRepository.GetAll();
        if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
        {
            query = query.Where(x => EF.Property<DateTime?>(x, "DeletedAt") == null);
        }

        var entities = await query.ToListAsync();
        var responseDto = _mapper.Map<List<TResponse>>(entities);
        return ServiceResult<List<TResponse>>.Success(responseDto);
    }

    public virtual async Task<ServiceResult<TResponse>> GetByIdAsync(int id)
    {
        if (typeof(TEntity).GetInterface(nameof(IEntity)) == null)
        {
            return ServiceResult<TResponse>.Fail("Invalid entity type");
        }

        var entity = await _genericRepository
            .Where(x => EF.Property<DateTime?>(x, "DeletedAt") == null)
            .FirstOrDefaultAsync(x => ((IEntity)x).Id == id);

        if (entity is null)
            return ServiceResult<TResponse>.Fail("Entity not found");

        var responseDto = _mapper.Map<TResponse>(entity);
        return ServiceResult<TResponse>.Success(responseDto);

        #region Solution With Reflections

        // var entityType = typeof(TEntity);
        // var idProperty = entityType.GetProperty("Id");
        // if (idProperty is null)
        //     return ServiceResult<TResponse>.Fail("Invalid entity type");
        //
        // var entity = await _genericRepository
        //     .Where(x => EF.Property<DateTime?>(x, "DeletedAt") == null)
        //     .FirstOrDefaultAsync(x => (int)idProperty.GetValue(x)! == id);
        //
        // if (entity is null)
        //     return ServiceResult<TResponse>.Fail("Entity not found");
        //
        // var responseDto = _mapper.Map<TResponse>(entity);
        // return ServiceResult<TResponse>.Success(responseDto);

        #endregion
    }

    public virtual async Task<ServiceResult<TResponse>> CreateAsync(TCreateRequest request)
    {
        var entity = _mapper.Map<TEntity>(request);
        await _genericRepository.CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        var responseDto = _mapper.Map<TResponse>(entity);
        return ServiceResult<TResponse>.Success(responseDto);
    }

    public virtual async Task<ServiceResult> UpdateAsync(int id, TUpdateRequest request)
    {
        var entity = await _genericRepository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult.Fail($"{typeof(TEntity).Name} with Id: {id} not found");
        _mapper.Map(request, entity);
        _genericRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public virtual async Task<ServiceResult> DeleteAsync(int id)
    {
        var entity = await _genericRepository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult.Fail($"{typeof(TEntity).Name} with Id: {id} not found");
        _genericRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public ServiceResult<IQueryable<TResponse>> Where(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = _genericRepository.Where(predicate)
            .Select(x => _mapper.Map<TResponse>(x));
        return ServiceResult<IQueryable<TResponse>>.Success(entities);
    }
}