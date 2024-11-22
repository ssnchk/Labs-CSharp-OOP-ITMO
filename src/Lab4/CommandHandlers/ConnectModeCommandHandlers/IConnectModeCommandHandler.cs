using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectModeCommandHandlers;

public interface IConnectModeCommandHandler
{
    IConnectModeCommandHandler AddNext(IConnectModeCommandHandler handler);

    ICommand? Handle(IEnumerator<string> request, string address);
}