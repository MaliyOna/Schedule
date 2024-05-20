namespace ScheduleAPI.Controllers;

public interface IGenericController<TDto>
{
    Task<TDto> Create(TDto dto, CancellationToken cancellationToken);
    Task Delete(string id, CancellationToken cancellationToken);
    Task<IEnumerable<TDto>> GetAll(CancellationToken cancellationToken);
    Task<TDto> GetById(string id, CancellationToken cancellationToken);
    Task<TDto> Update(TDto dto, CancellationToken cancellationToken);
}
