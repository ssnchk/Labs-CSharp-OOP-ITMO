﻿using Lab5.Contracts.Admins.ResultTypes;
using Lab5.Contracts.User;
using Lab5.Models.BankAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Authentication.LoginAsClient;

public class ClientLoginScenario : IScenario
{
    private readonly IUserService _service;

    public ClientLoginScenario(
        IUserService service)
    {
        _service = service;
    }

    public string Name => "Login as Client";

    public void Run()
    {
        long bankAccountId = AnsiConsole.Ask<long>("Enter bank account ID");
        string pincode = AnsiConsole.Ask<string>("Enter pincode");

        LoginResult result = _service.Login(bankAccountId, new PinCode(pincode));

        string message = result switch
        {
            LoginResult.Success => "Successful login as User",
            LoginResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}