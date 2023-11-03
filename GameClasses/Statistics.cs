namespace walkingGame.GameClasses;
using System;
using System.Collections.Generic;

public class Statistics
{
    private List<Person> person;

    public PersonStatistics()
    {
        persons = new List<Person>();
    }

    public void AddPlayer(Person person)
    {
        persons.Add(person);
        SortPlayers();
    }

    public void SortPersons()
    {
        persons.Sort((p1, p2) => p2.Score.CompareTo(p1.Score));
    }

    public void PrintStatistics()
    {
        Console.WriteLine("Player Statistics:");
        for (int i = 0; i < persons.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {persons[i].Name} - {persons[i].Score} points");
        }
    }
}
}