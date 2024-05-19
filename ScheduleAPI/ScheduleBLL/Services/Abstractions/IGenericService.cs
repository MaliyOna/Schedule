namespace ScheduleBLL.Services.Abstractions;
public interface IGenericService<TModel>
{
    Task<TModel> Create(TModel element, CancellationToken cancellationToken);
    Task Delete(string id, CancellationToken cancellationToken);
    Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken);
    Task<TModel> Update(TModel element, CancellationToken cancellationToken);
    Task<TModel> GetById(string id, CancellationToken cancellationToken);
}
