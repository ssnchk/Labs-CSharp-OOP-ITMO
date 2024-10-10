using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;

public interface IRouteSection
{
    PassRouteSectionResult PassResult(TrainInfo.Entities.Train train);
}