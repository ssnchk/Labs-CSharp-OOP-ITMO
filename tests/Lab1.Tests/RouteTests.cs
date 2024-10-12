using Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;
using Xunit;

namespace Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void PassRoute_ShouldReturnSuccess_WhenTrainPassesPowerMagneticRoadAndMagneticRoad()
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(10);

        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);
        var firstSection = new PowerMagneticRoad(new Distance(100), new Strength(10));
        var secondSection = new MagneticRoad(new Distance(100));

        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
                secondSection,
            },
            maxRouteStopSpeed);

        // act
        PassRouteResult result = route.PassRoute(train);

        // assert
        Assert.True(result is PassRouteResult.Success);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainExceedsMaxSpeedOnPowerMagneticRoad()
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(9);

        var firstSection = new PowerMagneticRoad(new Distance(100), new Strength(100));
        var secondSection = new MagneticRoad(new Distance(100));
        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);

        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
                secondSection,
            },
            maxRouteStopSpeed);

        // act
        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        // assert
        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.TrainActionResult is StopTrainResult.Failure);
    }

    [Fact]
    public void PassRoute_ShouldReturnSuccess_WhenTrainPassesPowerMagneticRoadAndStation()
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(10);

        var firstSection = new PowerMagneticRoad(new Distance(100), new Strength(10));
        var secondSection = new MagneticRoad(new Distance(100));
        var thirdSection = new Station(new TimeSpan(5), new Speed(10));
        var fourthSection = new MagneticRoad(new Distance(100));
        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);

        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
                secondSection,
                thirdSection,
                fourthSection,
            },
            maxRouteStopSpeed);

        // act
        PassRouteResult result = route.PassRoute(train);

        // assert
        Assert.True(result is PassRouteResult.Success);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainExceedsMaxSpeedAtStation()
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(10);

        var firstSection = new PowerMagneticRoad(new Distance(100), new Strength(100));
        var secondSection = new Station(new TimeSpan(5), new Speed(9));
        var thirdSection = new MagneticRoad(new Distance(100));
        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);

        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
                secondSection,
                thirdSection,
            },
            maxRouteStopSpeed);

        // act
        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        // assert
        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.TrainActionResult is StopTrainResult.Failure);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainExceedsMaxSpeedAtStationButAllowedAtStation()
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(9);

        var firstSection = new PowerMagneticRoad(new Distance(100), new Strength(100));
        var secondSection = new MagneticRoad(new Distance(100));
        var thirdSection = new Station(new TimeSpan(5), new Speed(10));
        var fourthSection = new MagneticRoad(new Distance(100));
        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);
        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
                secondSection,
                thirdSection,
                fourthSection,
            },
            maxRouteStopSpeed);

        // act
        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        // assert
        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.TrainActionResult is StopTrainResult.Failure);
    }

    [Fact]
    public void PassRoute_ShouldReturnSuccess_WhenTrainPassesComplexRouteWithPowerMagneticRoadsAndStations()
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(20);

        var firstSection = new PowerMagneticRoad(new Distance(100), new Strength(100));
        var secondSection = new MagneticRoad(new Distance(100));
        var thirdSection = new PowerMagneticRoad(new Distance(100), new Strength(-10));
        var fourthSection = new Station(new TimeSpan(5), new Speed(19));
        var fifthSection = new MagneticRoad(new Distance(100));
        var sixthSection = new PowerMagneticRoad(new Distance(100), new Strength(10));
        var seventhSection = new MagneticRoad(new Distance(100));
        var eighthSection = new PowerMagneticRoad(new Distance(100), new Strength(-10));
        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);

        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
                secondSection,
                thirdSection,
                fourthSection,
                fifthSection,
                sixthSection,
                seventhSection,
                eighthSection,
            },
            maxRouteStopSpeed);

        // act
        PassRouteResult result = route.PassRoute(train);

        // assert
        Assert.True(result is PassRouteResult.Success);
    }

    [Fact]
    public void PassRoute_ShouldReturnFailure_WhenTrainPassesMagneticRoad()
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(10);

        var firstSection = new MagneticRoad(new Distance(100));
        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);
        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
            },
            maxRouteStopSpeed);

        // act
        PassRouteResult result = route.PassRoute(train);

        // assert
        Assert.True(result is PassRouteResult.Failure);
    }

    [Theory]
    [InlineData(1, 2)]
    public void
PassRoute_ShouldReturnFailure_WhenTrainPassesPowerMagneticRoadWithDistanceXAndAppliedForceYAndPowerMagneticRoadWithDistanceXAndAppliedForceMinus2Y(double x, double y)
    {
        // arrange
        var trainWeight = new Weight(100);
        var trainMaxStrength = new Strength(100);
        var trainAccuracy = new TimeSpan(10);
        var maxRouteStopSpeed = new Speed(10);

        var firstSection = new PowerMagneticRoad(new Distance(x), new Strength(y));
        var secondSection = new PowerMagneticRoad(new Distance(x), new Strength(-2 * y));
        var train = new Train(trainWeight, trainMaxStrength, trainAccuracy);
        var route = new Route(
            new List<IRouteSection>
            {
                firstSection,
                secondSection,
            },
            maxRouteStopSpeed);

        // act
        var passRouteResult = route.PassRoute(train) as PassRouteResult.Failure;

        // assert
        Assert.True(passRouteResult is not null);
        Assert.True(passRouteResult.TrainActionResult is PassDistanceResult.Failure);
    }
}