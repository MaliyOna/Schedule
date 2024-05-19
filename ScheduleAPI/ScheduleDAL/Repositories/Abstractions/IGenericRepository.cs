using ScheduleDAL.Entities;

namespace ScheduleDAL.Repositories.Abstractions;
public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
{
    Task<TEntity> Create(TEntity element, CancellationToken cancellationToken);
    Task Delete(string id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);
    Task<TEntity> Update(TEntity element, CancellationToken cancellationToken);
    Task<TEntity?> GetById(string id, CancellationToken cancellationToken);
}
