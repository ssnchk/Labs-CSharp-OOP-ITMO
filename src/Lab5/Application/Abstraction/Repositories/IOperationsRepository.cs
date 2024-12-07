using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;

public interface IOperationsRepository
{
    IEnumerable<Operation> GetOperationsByBankAccountId(long bankAccountId);
}