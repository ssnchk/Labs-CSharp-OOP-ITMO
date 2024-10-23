using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IWithPointsAmount
{
    public Points PointsAmount { get; }
}