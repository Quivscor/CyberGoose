using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private Scene scoreScene;

    protected virtual void Awake()
    {
        Debug.Log("Playing mini game: " + this.name);
        LoadNextScene = null;

        SetTimerCondition(timerIsWinCondition);
        scoreScene = SceneManager.GetSceneByName("ScoreScene");
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
        GameManager.Instance.LoseLife();
        LoadNextScene += GameManager.Instance.LoseMiniGame;
        countdownToNextScene = true;
        StartCoroutine(DisplayScoreScene());
    }

    ///<summary>
    ///Defines what happens after won mini game.
    ///</summary>
    public virtual void OnWin()
    {
        if (countdownToNextScene)
            return;
        Debug.Log("Victory!");
        GameManager.Instance.GainPoints();
        LoadNextScene += GameManager.Instance.WinMiniGame;
        countdownToNextScene = true;
        StartCoroutine(DisplayScoreScene());
    }

    ///<summary>
    ///Returns length of mini game time in seconds.
    ///</summary>
    public float GetMiniGameTime()
    {
        return miniGameTime;
    }

    IEnumerator DisplayScoreScene()
    {
        SceneManager.LoadScene("ScoreScene", LoadSceneMode.Additive);
        yield return new WaitForSeconds(2f);
        SceneManager.UnloadSceneAsync("ScoreScene");
    }
}
