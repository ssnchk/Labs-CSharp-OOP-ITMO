using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class DisconnectCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "disconnect")
            return Next?.Handle(request);

        return new DisconnectCommand();
    }
}