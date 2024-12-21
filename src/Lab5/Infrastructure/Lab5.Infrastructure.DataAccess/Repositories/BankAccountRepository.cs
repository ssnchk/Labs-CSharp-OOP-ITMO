using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Abstraction.Repositories;
using Lab5.Models.BankAccounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public BankAccount? FindBankAccountById(long id)
    {
        const string sql = """
                           select bank_account_id, bank_account_pin_code, balance 
                           from bank_accounts
                           where bank_account_id = :id
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
        {
            connection.Close();
            return null;
        }

        var bankAccount = new BankAccount(
            reader.GetInt64(0),
            new PinCode(reader.GetFieldValue<string>(1)),
            reader.GetDecimal(2));

        connection.Close();

        return bankAccount;
    }

    public bool TryUpdateBankAccount(BankAccount bankAccount)
    {
        const string sql = """
                           update bank_accounts
                           set balance = :balance
                           where bank_account_id = :bank_account_id
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("balance", bankAccount.Balance)
            .AddParameter("bank_account_id", bankAccount.Id);

        int rowsChanged = command.ExecuteNonQuery();

        connection.Close();

        if (rowsChanged == -1)
            return false;

        return true;
    }

    public bool TryCreateBankAccount(long id, PinCode pinCode)
    {
        const string sql = """
                           insert into bank_accounts
                           (bank_account_id, bank_account_pin_code, balance)
                           values
                           (:bank_account_id, :bank_account_pin_code, :balance)
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        var newBankAccount = new BankAccount(id, pinCode, 0);

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("bank_account_id", newBankAccount.Id)
            .AddParameter("bank_account_pin_code", newBankAccount.Code.Value)
            .AddParameter("balance", newBankAccount.Balance);

        int rowsChanged = command.ExecuteNonQuery();

        connection.Close();

        if (rowsChanged == -1)
            return false;

        return true;
    }
}