using Itmo.ObjectOrientedProgramming.Lab2.Repositories.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class InMemoryRepository<T> : IRepository<T>
    where T : IIdentifiable
{
    private readonly Dictionary<long, T> _items = [];

    public GetItemResult<T> GetItem(long id)
    {
        return _items.ContainsKey(id)
            ? new GetItemResult<T>.Success(_items[id])
            : new GetItemResult<T>.Failure("Item not found");
    }

    public AddItemResult AddItem(T item)
    {
        _items[item.Id] = item;
        return new AddItemResult.Success();
    }

    public RemoveItemResult RemoveItem(long id)
    {
        if (!_items.ContainsKey(id))
            return new RemoveItemResult.Failure("Item not found");

        _items.Remove(id);
        return new RemoveItemResult.Success();
    }
}
