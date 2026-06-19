namespace WebApp.Services;

public interface ICrudService<T> where T : class
{
    IReadOnlyCollection<T> GetAll();
    T? GetById(Guid id);
    T Create(T entity);
    bool Update(Guid id, T entity);
    bool Delete(Guid id);
}
