using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Image image;

    //Time flow and clock display values
    private float currentTime;
    private float maxTime;

    //Event handling what happens when timer reaches 0.
    public delegate void EndCondition();
    public event EndCondition OnTimeOut;

    private bool timedOut = false;

    private void Start()
    {
        image = GetComponent<Image>();
        InitTimer(GameManager.Instance.Score.gamesWon);
    }

    ///<summary>
    ///Resets timer. Adjusts time, taking amount of games won into consideration.
    ///</summary>
    public void InitTimer(int gamesWon)
    {
        maxTime = FindObjectOfType<MiniGameManager>().GetComponent<MiniGameManager>().GetMiniGameTime()
            - (Mathf.Log10(gamesWon + 1) / 0.7f);
        currentTime = maxTime;
    }

    ///<summary>
    ///Handles time flow. Starts the event when timer reaches 0.
    ///</summary>
    public void FixedUpdate()
    {
        currentTime -= Time.fixedDeltaTime;

        if (currentTime <= 0 && !timedOut)
        {
            timedOut = true;
            OnTimeOut?.Invoke();
            
        }
    }

    ///<summary>
    ///Updates the clock animation.
    ///</summary>
    public void Update()
    {
        image.fillAmount = currentTime / maxTime;    
    }
}
