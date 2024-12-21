using Lab5.Contracts.BankAccounts.ResultTypes;
using Lab5.Models.BankAccounts.Operations;

namespace Lab5.Contracts.BankAccounts;

public interface IBankAccountOperationsService
{
    AddOperationResult TryAddOperation(Operation operation);

    GetHistoryResult GetHistory(long id);
}