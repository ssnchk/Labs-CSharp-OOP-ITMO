using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts.Operations;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> GetOperationsByBankAccountId(long bankAccountId)
    {
        const string sql = """
                           select bank_account_operations_id,operation_type, amount, date 
                           from bank_account_operations
                           where bank_account_id = :bankAccountId
                           """;

        ValueTask<NpgsqlConnection> task = _connectionProvider.GetConnectionAsync(default);

        if (!task.IsCompletedSuccessfully)
            throw new InvalidOperationException();

        NpgsqlConnection connection = task
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("bankAccountId", bankAccountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(
                reader.GetInt64(0),
                reader.GetFieldValue<OperationType>(1),
                reader.GetDecimal(2),
                reader.GetDateTime(3),
                bankAccountId);
        }
    }

    public bool TryAddOperation(Operation operation)
    {
        const string sql = """
                           insert into bank_account_operations
                           (bank_account_operations_id, bank_account_id, operation_type, amount, date)
                           values
                           (:bank_account_operations_id, :bankAccountId, :operationType, :amount, :date)
                           """;

        ValueTask<NpgsqlConnection> task = _connectionProvider.GetConnectionAsync(default);

        if (!task.IsCompletedSuccessfully)
            throw new InvalidOperationException();

        NpgsqlConnection connection = task
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("bank_account_operations_id", operation.Id)
            .AddParameter("bankAccountId", operation.BankAccountId)
            .AddParameter("operationType", operation.Type)
            .AddParameter("amount", operation.Amount)
            .AddParameter("date", operation.Date);

        int rowsChanged = command.ExecuteNonQuery();

        if (rowsChanged == -1)
            return false;

        return true;
    }
}