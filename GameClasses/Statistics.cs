namespace walkingGame.GameClasses;
using System;
using System.Collections.Generic;

public class Statistics
{
    private List<Person> person = new();

    public void AddPlayer(Person p)
    {
        person.Add(p);
        SortPersons();
    }

    public void SortPersons()
    {
        person.Sort((p1, p2) => p2.Score.CompareTo(p1.Score));
    }

    public void PrintStatistics()
    {
        Console.WriteLine("Player Statistics:");
        for (int i = 0; i < person.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {person[i].Name} - {person[i].Score} points");
        }
    }
}
