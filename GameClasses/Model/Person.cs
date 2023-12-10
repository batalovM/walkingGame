using System.Security.Cryptography;
using walkingGame.GameClasses.Interfaces;

namespace walkingGame.GameClasses.Model;

public abstract class Person : IRoll
{
    private RNGCryptoServiceProvider _rng = new();
    public int Score { get; set; }

    public void Move()
    {
        Score += Roll();
    }
    
    public int Roll()
    {
        var randomNumber = new byte[1];
        _rng.GetBytes(randomNumber);
        return (randomNumber[0] % 6) + 1;
    }
}