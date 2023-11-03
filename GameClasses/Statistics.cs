namespace walkingGame.GameClasses;
using System;
using System.Collections.Generic;

public class Statistics
{
    private List<Player> players;

    public PlayerStatistics()
    {
        players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
        SortPlayers();
    }

    public void SortPlayers()
    {
        players.Sort((p1, p2) => p2.Score.CompareTo(p1.Score));
    }

    public void PrintStatistics()
    {
        Console.WriteLine("Player Statistics:");
        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {players[i].Name} - {players[i].Score} points");
        }
    }
}
}