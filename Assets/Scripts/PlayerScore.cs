using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Holds information about amount of points earned, time passed since the start of a run
///and amount of mini games that were succesfully completed.
///</summary>
[System.Serializable]
public class PlayerScore
{
    public PlayerScore()
    {
        previousPoints = 0;
        points = 0;
        time = 0;
        gamesWon = 0;
    }

    public int previousPoints { get; set; }
    public int points { get; set; }
    public float time { get; set; }
    public int gamesWon { get; set; }
}
