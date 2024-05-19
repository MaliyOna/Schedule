using AutoMapper;
using ScheduleBLL.Services.Abstractions;
using ScheduleDAL.Entities;
using ScheduleDAL.Repositories.Abstractions;
using ScheduleDomain.Exceptions;

namespace ScheduleBLL.Services;
public class GenericService<TModel, TEntity> : IGenericService<TModel>
    where TEntity : IBaseEntity
{
    protected readonly IMapper _mapper;
    protected readonly IGenericRepository<TEntity> _genericRepository;

    public GenericService(IMapper mapper, IGenericRepository<TEntity> genericRepository)
    {
        _mapper = mapper;
        _genericRepository = genericRepository;
    }

    public virtual async Task<TModel> Create(TModel element, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(element);

        var resultEntity = await _genericRepository.Create(entity, cancellationToken);

        return _mapper.Map<TModel>(resultEntity);
    }

    public async Task Delete(string id, CancellationToken cancellationToken) => await _genericRepository.Delete(id, cancellationToken);

    public async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken)
    {
        var resultEntity = await _genericRepository.GetAll(cancellationToken);
        return _mapper.Map<List<TModel>>(resultEntity);
    }

    public virtual async Task<TModel> Update(TModel element, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(element);

        var findUser = await GetById(entity.Id, cancellationToken);

        if (findUser != null)
        {
            var resultEntity = await _genericRepository.Update(entity, cancellationToken);

            return _mapper.Map<TModel>(resultEntity);
        }
        else
        {
            throw new NotFoundException("Entity with Id {element.Id} not found.");
        }
    }

    public async Task<TModel> GetById(string id, CancellationToken cancellationToken)
    {
        var resultEntity = await _genericRepository.GetById(id, cancellationToken);

        return _mapper.Map<TModel>(resultEntity);
    }
}
