﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Amount of scenes in the project that ARE NOT mini games
    public static readonly int NonMiniGameScenes = 2;
    //Amount of starting lives
    public static readonly int StartingLives = 3;

    public PlayerScore Score { get; private set; }
    public int Lives{ get; private set; }

    private List<int> miniGameIndex;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            ResetGame();
        }
        else
            Destroy(this.gameObject);

        if (miniGameIndex == null)
            FillMiniGameList();

    }

    ///<summary>
    ///At the beginning of the game, gathers all scenes and puts the build indexes in the list. It excludes
    ///scenes that are not mini games. Those scenes are supposed to be in the starting indexes of the scene list.
    ///</summary>
    private void FillMiniGameList()
    {
        int size = SceneManager.sceneCountInBuildSettings;
        int startValue = GameManager.NonMiniGameScenes;

        miniGameIndex = new List<int>();

        for(int i = 0; i < size - startValue; i++)
        {
            miniGameIndex.Add(startValue + i);
        }
    }

    ///<summary>
    ///Handles victory in a mini game. Adds points and time, increments amount of victories in the Score variable.
    ///</summary>
    public void WinMiniGame()
    {
        SceneManager.LoadScene(GetNextMiniGame());
    }

    ///<summary>
    ///Handles loss in a mini game.
    ///</summary>
    public void LoseMiniGame()
    {
        if (CheckGameOver())
            GameOver();
        else
            SceneManager.LoadScene(GetNextMiniGame());
    }

    /// <summary>
    /// Decrements 1 life from the Lives variable.
    /// </summary>
    public void LoseLife()
    {
        Score.previousPoints = Score.points;
        Lives--;
    }

    /// <summary>
    /// Increases score by adding points, incrementing amount of games won.
    /// </summary>
    public void GainPoints()
    {
        Score.gamesWon += 1;
        Score.previousPoints = Score.points;
        Score.points += 1 * Score.gamesWon;
    }

    ///<summary>
    ///Finds a random scene index from the list of indexes. It assumes that the indexes are sorted.
    ///</summary>
    ///<returns>
    ///Index of mini game scene.
    /// </returns>
    public int GetNextMiniGame()
    {
        var thisMiniGameID = SceneManager.GetActiveScene().buildIndex;
        var randomMiniGameID = Random.Range(miniGameIndex[0], miniGameIndex[miniGameIndex.Count - 1] + 1);
        while(randomMiniGameID == thisMiniGameID)
        {
            randomMiniGameID = Random.Range(miniGameIndex[0], miniGameIndex[miniGameIndex.Count - 1] + 1);
        }
        //Assume miniGameIndex is sorted and build indexes are next to each other.
        return randomMiniGameID;
    }

    ///<summary>
    ///Returns true if game over is supposed to happen.
    ///</summary>
    private bool CheckGameOver()
    {
        return Lives <= 0;
    }

    ///<summary>
    ///Handles end of a run.
    ///</summary>
    private void GameOver()
    {
        //Serialize score maybe?
        ScoreSerializer.SaveHighScore(Score);
        Score = null;
        SceneManager.LoadScene("MainMenuScene");
        //TODO: Return to main menu.
    }

    ///<summary>
    ///Reset initialized score and lives. Should be called at the start of new run.
    ///</summary>
    public void ResetGame()
    {
        Lives = StartingLives;
        Score = new PlayerScore();
    }
}
