using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Abstraction.Repositories;
using Lab5.Models.BankAccounts.Operations;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountOperationRepository : IBankAccountOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountOperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public bool TryAddOperation(Operation operation)
    {
        const string sql = """
                           insert into bank_account_operations
                           (bank_account_id, type, amount, date)
                           values
                           (:bankAccountId, :operationType, :amount, :date)
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("bankAccountId", operation.BankAccountId)
            .AddParameter("operationType", operation.Type)
            .AddParameter("amount", operation.Amount)
            .AddParameter("date", operation.Date);

        int rowsChanged = command.ExecuteNonQuery();

        connection.Close();

        if (rowsChanged == -1)
            return false;

        return true;
    }

    public IEnumerable<Operation> GetOperationsByAccountId(long id)
    {
        const string sql = """
                           select type, amount, date 
                           from bank_account_operations
                           where bank_account_id = :bankAccountId
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("bankAccountId", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(
                reader.GetFieldValue<OperationType>(0),
                reader.GetDecimal(1),
                reader.GetDateTime(2),
                id);
        }

        connection.Close();
    }
}