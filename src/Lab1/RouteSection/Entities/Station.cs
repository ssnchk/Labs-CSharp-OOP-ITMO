using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;

public class Station : IRouteSection
{
    private readonly TimeSpan _breakTime;
    private readonly Speed _maxSpeed;

    public Station(TimeSpan breakTime, Speed maxSpeed)
    {
        _breakTime = breakTime;
        _maxSpeed = maxSpeed;
    }

    public PassRouteSectionResult PassResult(TrainInfo.Entities.Train train)
    {
        if (train.StopTrain(_maxSpeed) is StopTrainResult.Failure stopTrainResult)
            return new PassRouteSectionResult.Failure(stopTrainResult);

        return new PassRouteSectionResult.Success(_breakTime);
    }
}
