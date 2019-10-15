using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Holds information about amount of points earned, time passed since the start of a run
///and amount of mini games that were succesfully completed.
///</summary>
public class PlayerScore
{
    public int points { get; set; }
    public float time { get; set; }
    public int gamesWon { get; set; }
}
