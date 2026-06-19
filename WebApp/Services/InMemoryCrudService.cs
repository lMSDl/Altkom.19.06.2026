namespace WebApp.Services;

public class InMemoryCrudService<T> : ICrudService<T> where T : class
{
    private readonly Dictionary<Guid, T> _items = new();
    private readonly Func<T, Guid> _getId;
    private readonly Action<T, Guid> _setId;

    public InMemoryCrudService(Func<T, Guid> getId, Action<T, Guid> setId)
    {
        _getId = getId;
        _setId = setId;
    }

    public IReadOnlyCollection<T> GetAll() => _items.Values.ToList().AsReadOnly();

    public T? GetById(Guid id)
    {
        _items.TryGetValue(id, out var entity);
        return entity;
    }

    public T Create(T entity)
    {
        var id = _getId(entity);
        if (id == Guid.Empty || _items.ContainsKey(id))
        {
            id = Guid.NewGuid();
            _setId(entity, id);
        }

        _items[id] = entity;
        return entity;
    }

    public bool Update(Guid id, T entity)
    {
        if (!_items.ContainsKey(id))
        {
            return false;
        }

        _setId(entity, id);
        _items[id] = entity;
        return true;
    }

    public bool Delete(Guid id) => _items.Remove(id);
}
