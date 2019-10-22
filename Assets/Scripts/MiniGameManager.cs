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
    protected bool timerIsWinCondition;

    private float timeBeforeSceneChange = 2f;
    private bool countdownToNextScene = false;

    public delegate void NextScene();
    public event NextScene LoadNextScene;

    protected virtual void Awake()
    {
        Debug.Log("Playing mini game: " + this.name);
        LoadNextScene = null;

        SetTimerCondition(timerIsWinCondition);
    }

    protected virtual void FixedUpdate()
    {
        if(countdownToNextScene)
        {
            timeBeforeSceneChange -= Time.fixedDeltaTime;
            if (timeBeforeSceneChange <= 0)
                LoadNextScene?.Invoke();
        }
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
        if (countdownToNextScene)
            return;
        Debug.Log("Defeat!");
        LoadNextScene += GameManager.Instance.LoseMiniGame;
        countdownToNextScene = true;
    }

    ///<summary>
    ///Defines what happens after won mini game.
    ///</summary>
    public virtual void OnWin()
    {
        if (countdownToNextScene)
            return;
        Debug.Log("Victory!");
        LoadNextScene += GameManager.Instance.WinMiniGame;
        countdownToNextScene = true;
    }

    ///<summary>
    ///Returns length of mini game time in seconds.
    ///</summary>
    public float GetMiniGameTime()
    {
        return miniGameTime;
    }
}
