using Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;

namespace Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void PassRoute_ShouldReturnSuccess_WhenTrainPassesPowerMagneticRoadAndMagneticRoad()
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new PowerMagneticRoad(100, 10),
                new MagneticRoad(100),
            },
            10);

        PassRouteResult result = route.PassRoute(train);

        Assert.True(result is PassRouteResult.Success);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainExceedsMaxSpeedOnPowerMagneticRoad()
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new PowerMagneticRoad(100, 100),
                new MagneticRoad(100),
            },
            9);

        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.FailureResult is StopTrainResult.Failure);
    }

    [Fact]
    public void PassRoute_ShouldReturnSuccess_WhenTrainPassesPowerMagneticRoadAndStation()
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new PowerMagneticRoad(100, 10),
                new MagneticRoad(100),
                new Station(5, 10),
                new MagneticRoad(100),
            },
            10);

        PassRouteResult result = route.PassRoute(train);

        Assert.True(result is PassRouteResult.Success);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainExceedsMaxSpeedAtStation()
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new PowerMagneticRoad(100, 100),
                new Station(5, 9),
                new MagneticRoad(100),
            },
            10);

        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.FailureResult is StopTrainResult.Failure);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainExceedsMaxSpeedAtStationButAllowedAtStation()
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new PowerMagneticRoad(100, 100),
                new MagneticRoad(100),
                new Station(5, 10),
                new MagneticRoad(100),
            },
            9);

        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.FailureResult is StopTrainResult.Failure);
    }

    [Fact]
    public void PassRoute_ShouldReturnSuccess_WhenTrainPassesComplexRouteWithPowerMagneticRoadsAndStations()
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new PowerMagneticRoad(100, 100),
                new MagneticRoad(100),
                new PowerMagneticRoad(100, -10),
                new Station(5, 19),
                new MagneticRoad(100),
                new PowerMagneticRoad(100, 10),
                new MagneticRoad(100),
                new PowerMagneticRoad(100, -10),
            },
            20);

        PassRouteResult result = route.PassRoute(train);

        Assert.True(result is PassRouteResult.Success);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainPassesMagneticRoad()
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new MagneticRoad(100),
            },
            10);

        PassRouteResult result = route.PassRoute(train);

        Assert.True(result is PassRouteResult.Failure);
    }

    [Theory]
    [InlineData(1, 2)]
    public void
PassRoute_ShouldReturnFailure_WhenTrainPassesPowerMagneticRoadWithDistanceXAndAppliedForceYAndPowerMagneticRoadWithDistanceXAndAppliedForceMinus2Y(double x, double y)
    {
        var train = new Train(100, 100, 10);
        var route = new Route(
            new List<IRouteSection>
            {
                new PowerMagneticRoad(x, y),
                new PowerMagneticRoad(x, -2 * y),
            },
            10);

        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.FailureResult is PassDistanceResult.Failure);
    }
}