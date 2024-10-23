namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T> where T : class
{
    public GetItemResult<T> GetItem(Guid id);

    public AddItemResult AddItem(Guid id, T item);

    public RemoveItemResult RemoveItem(Guid id);
}