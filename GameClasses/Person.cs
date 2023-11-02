using System;

namespace walkingGame.GameClasses;

public class Person
{
    private int possition;
    private static string name;

    public Person(int possition)
    {
        this.possition = possition;
    }

    public int Possition
    {
        get => possition;
        set => possition = value;
    }

    public static string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
}