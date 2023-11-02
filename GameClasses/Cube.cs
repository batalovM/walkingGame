using System;

namespace walkingGame.GameClasses;

public class Cube
{
    private Random random = new();

    public int Roll()
    {
        return random.Next(1, 7);
    }
}