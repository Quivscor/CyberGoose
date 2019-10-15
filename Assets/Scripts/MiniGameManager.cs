using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    protected float miniGameTime;

    [SerializeField]
    protected new string name;

    [SerializeField]
    private bool timerIsWinCondition;

    protected virtual void Awake()
    {
        Debug.Log("Playing mini game: " + this.name);

        SetTimerCondition(timerIsWinCondition);
    }

    ///<summary>
    ///Sets either a win or lose condition for event in which timer runs out. Default setting is that the game is won.
    ///</summary>
    protected void SetTimerCondition(bool win = true)
    {
        if (win)
            GameObject.Find("Timer").GetComponent<Timer>().OnTimeOut += OnWin;
        else
            GameObject.Find("Timer").GetComponent<Timer>().OnTimeOut += OnDefeat;
    }

    ///<summary>
    ///Defines what happens after lost mini game.
    ///</summary>
    public virtual void OnDefeat()
    {
        Debug.Log("Defeat!");
        GameManager.Instance.LoseMiniGame();
    }

    ///<summary>
    ///Defines what happens after won mini game.
    ///</summary>
    public virtual void OnWin()
    {
        Debug.Log("Victory!");
        GameManager.Instance.WinMiniGame();
    }

    ///<summary>
    ///Returns length of mini game time in seconds.
    ///</summary>
    public float GetMiniGameTime()
    {
        return miniGameTime;
    }
}
