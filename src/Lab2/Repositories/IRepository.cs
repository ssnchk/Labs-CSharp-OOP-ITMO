namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T> where T : IIdentifiable
{
    public GetItemResult<T> GetItem(long id);

    public AddItemResult AddItem(T item);

    public RemoveItemResult RemoveItem(long id);
}