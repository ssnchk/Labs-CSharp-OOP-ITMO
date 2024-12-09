using Itmo.ObjectOrientedProgramming.Lab5.Application.Application.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5;

public class Program
{
    public static void Main(string[] args)
    {
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 6433;
                configuration.Username = "postgres";
                configuration.Password = "postgres";
                configuration.Database = "postgres";
                configuration.SslMode = "Prefer";
            })
            .AddPresentationConsole();

        ServiceProvider provider = collection.BuildServiceProvider();

        using IServiceScope scope = provider.CreateScope();

        scope.UseInfrastructureDataAccess();

        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();

        while (true)
        {
            scenarioRunner.Run();
            AnsiConsole.Clear();
        }
    }
}