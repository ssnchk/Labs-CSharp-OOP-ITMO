using Lab5.Models.BankAccounts.Operations;

namespace Lab5.Abstraction.Repositories;

public interface IBankAccountOperationsRepository
{
    bool TryAddOperation(Operation operation);

    IEnumerable<Operation> GetOperationsByAccountId(long id);
}