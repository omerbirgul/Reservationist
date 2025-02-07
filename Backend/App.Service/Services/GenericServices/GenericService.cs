using System.Linq.Expressions;
using System.Net;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Service.Services.GenericServices;

public class GenericService<TCreateRequest, TUpdateRequest, TResponse, TCreateResponse, TEntity>
    : IGenericService<TCreateRequest, TUpdateRequest, TResponse, TCreateResponse, TEntity>
    where TCreateRequest : class
    where TUpdateRequest : class
    where TResponse : class
    where TCreateResponse : class
    where TEntity : class
{

    private readonly IGenericRepository<TEntity> _genericRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<List<TResponse>>> GetAllAsync()
    {
        var entities = await _genericRepository.GetAll().ToListAsync();
        var responseDto = _mapper.Map<List<TResponse>>(entities);
        return ServiceResult<List<TResponse>>.Success(responseDto);
    }

    public async Task<ServiceResult<TResponse>> GetByIdAsync(int id)
    {
        var entity = await _genericRepository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<TResponse>.Fail($"{typeof(TEntity)} not found");
        var responseDto = _mapper.Map<TResponse>(entity);
        return ServiceResult<TResponse>.Success(responseDto);
    }

    public async Task<ServiceResult<TCreateResponse>> CreateAsync(TCreateRequest request)
    {
        var entity = _mapper.Map<TEntity>(request);
        await _genericRepository.CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        var responseDto = _mapper.Map<TCreateResponse>(entity);
        return ServiceResult<TCreateResponse>.Success(responseDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, TUpdateRequest request)
    {
        var entity = await _genericRepository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult.Fail($"{typeof(TEntity).Name} with Id: {id} not found");
        _mapper.Map(request, entity);
        _genericRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
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