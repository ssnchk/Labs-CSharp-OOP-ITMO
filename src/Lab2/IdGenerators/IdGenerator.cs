using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab2.IdGenerators;

public class IdGenerator
{
    public static long GenerateNewId()
    {
        byte[] randomNumber = new byte[8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        return BitConverter.ToInt64(randomNumber, 0);
    }
}