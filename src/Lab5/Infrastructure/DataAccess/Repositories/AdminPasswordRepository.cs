using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

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
            return null;

        return reader
            .GetString(0);
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

        if (executedRows == -1)
            return false;

        return true;
    }
}