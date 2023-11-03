using System;

namespace walkingGame.GameClasses;

public class Person
{
    private int possition;//pos y
    public string Name;
    private int id;
    public int Score;
    

    public Person(int possition)
    {
        this.possition = possition;
    }

    public int Possition
    {
        get => possition;
        set => possition = value;
    }

    
}