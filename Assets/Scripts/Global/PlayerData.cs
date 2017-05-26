using System.Collections.Generic;
using System;
using UnityEngine;

public class Game
{
    public DateTime startTime;
    public long numberSeconds;
    public int score;
}

public static class PlayerData {

    public static string Name;
    private static List<Game> Games;
    public static Color color;

    public static void Init(string name)
    {
        Name = name;
        Games = new List<Game>();
    }

    public static void AddGame(DateTime startTime, long numberSeconds, int score)
    {
        Games.Add(new Game { startTime = startTime, numberSeconds = numberSeconds, score = score });
    }

    public static Game GetLastGame()
    {
        if (Games == null || Games.Count == 0)
            return null;
        return Games[Games.Count - 1];
    }

}
