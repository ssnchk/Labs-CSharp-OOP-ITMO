using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    private readonly IOperationsRepository _operationsRepository;

    public BankAccountRepository(
        IPostgresConnectionProvider connectionProvider,
        IOperationsRepository operationsRepository)
    {
        _connectionProvider = connectionProvider;
        _operationsRepository = operationsRepository;
    }

    public BankAccount? FindBankAccountById(long id)
    {
        const string sql = """
                           select bank_account_id, bank_account_pin_code, balance 
                           from bank_accounts
                           where bank_account_id = :id
                           """;

        ValueTask<NpgsqlConnection> task = _connectionProvider.GetConnectionAsync(default);

        if (!task.IsCompletedSuccessfully)
            throw new InvalidOperationException();

        NpgsqlConnection connection = task
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new BankAccount(
            reader.GetInt64(0),
            reader.GetFieldValue<PinCode>(1),
            reader.GetDecimal(2),
            _operationsRepository.GetOperationsByBankAccountId(reader.GetInt64(0)));
    }

    public bool TryUpdateBankAccount(BankAccount bankAccount)
    {
        const string sql = """
                           update bank_accounts
                           set balance = :balance
                           where bank_account_id = :bank_account_id
                           """;

        ValueTask<NpgsqlConnection> task = _connectionProvider.GetConnectionAsync(default);

        if (!task.IsCompletedSuccessfully)
            throw new InvalidOperationException();

        NpgsqlConnection connection = task
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("balance", bankAccount.Balance)
            .AddParameter("bank_account_id", bankAccount.Id);

        int rowsChanged = command.ExecuteNonQuery();

        if (rowsChanged == -1)
            return false;

        return true;
    }

    public BankAccount? CreateBankAccount(PinCode pinCode)
    {
        const string sql = """
                           insert into bank_accounts
                           (bank_account_id, bank_account_pin_code, balance)
                           values
                           (:bank_account_id, :bank_account_pin_code, :balance)
                           """;

        ValueTask<NpgsqlConnection> task = _connectionProvider.GetConnectionAsync(default);

        if (!task.IsCompletedSuccessfully)
            throw new InvalidOperationException();

        NpgsqlConnection connection = task
            .GetAwaiter()
            .GetResult();

        var newBankAccount = new BankAccount(pinCode);

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("bank_account_id", newBankAccount.Id)
            .AddParameter("bank_account_pin_code", newBankAccount.PinCode)
            .AddParameter("balance", newBankAccount.Balance);

        int rowsChanged = command.ExecuteNonQuery();

        if (rowsChanged == -1)
            return null;

        return newBankAccount;
    }
}