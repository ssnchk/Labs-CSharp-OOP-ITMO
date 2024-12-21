using Lab5.Abstraction.Repositories;
using Lab5.Contracts.BankAccounts;
using Lab5.Contracts.BankAccounts.ResultTypes;
using Lab5.Models.BankAccounts.Operations;

namespace Lab5.Application.BankAccounts;

public class BankAccountOperationsService : IBankAccountOperationsService
{
    private readonly IBankAccountOperationsRepository _bankAccountRepository;

    public BankAccountOperationsService(IBankAccountOperationsRepository bankAccountRepository)
    {
        _bankAccountRepository = bankAccountRepository;
    }

    public AddOperationResult TryAddOperation(Operation operation)
    {
        return _bankAccountRepository
            .TryAddOperation(operation)
            ? new AddOperationResult.Success()
            : new AddOperationResult.Failure("Could not add operation");
    }

    public GetHistoryResult GetHistory(long id) =>
        new GetHistoryResult.Success(
            _bankAccountRepository.GetOperationsByAccountId(id).ToList().AsReadOnly());
}