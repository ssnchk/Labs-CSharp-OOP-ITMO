using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Abstraction.Repositories;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminPasswordRepository : IAdminPasswordRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminPasswordRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public string? GetAdminPassword()
    {
        const string sql = """
                           select password
                           from admin_password;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
        {
            connection.Close();
            return null;
        }

        string password = reader.GetString(0);

        connection.Close();

        return password;
    }

    public bool TrySetPassword(string password)
    {
        const string sql = """
                           update admin_password
                           set password = :password
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("password", password);

        int executedRows = command.ExecuteNonQuery();

        connection.Close();

        if (executedRows == -1)
            return false;

        return true;
    }
}