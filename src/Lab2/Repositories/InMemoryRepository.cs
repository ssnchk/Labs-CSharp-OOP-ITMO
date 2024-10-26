namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class InMemoryRepository<T> : IRepository<T>
{
    private readonly Dictionary<Guid, T> _items = [];

    public GetItemResult<T> GetItem(Guid id)
    {
        return _items.ContainsKey(id)
            ? new GetItemResult<T>.Success(_items[id])
            : new GetItemResult<T>.Failure("Item not found");
    }

    public AddItemResult AddItem(Guid id, T item)
    {
        if (!_items.ContainsKey(id))
            return new AddItemResult.Failure("Item already exists");

        _items[id] = item;
        return new AddItemResult.Success();
    }

    public RemoveItemResult RemoveItem(Guid id)
    {
        if (!_items.ContainsKey(id))
            return new RemoveItemResult.Failure("Item not found");

        _items.Remove(id);
        return new RemoveItemResult.Success();
    }
}
