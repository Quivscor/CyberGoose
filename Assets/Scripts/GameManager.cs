using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Amount of scenes in the project that ARE NOT mini games
    public static readonly int NonMiniGameScenes = 1;
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
        Score.gamesWon++;
        Score.points += 10 * Score.gamesWon;

        SceneManager.LoadScene(GetNextMiniGame());
    }

    ///<summary>
    ///Handles loss in a mini game. Decrements 1 life from the Lives variable
    ///</summary>
    public void LoseMiniGame()
    {
        Lives--;
        if (CheckGameOver())
            GameOver();
        else
            SceneManager.LoadScene(GetNextMiniGame());
    }

    ///<summary>
    ///Finds a random scene index from the list of indexes. It assumes that the indexes are sorted.
    ///</summary>
    ///<returns>
    ///Index of mini game scene.
    /// </returns>
    public int GetNextMiniGame()
    {
        //Assume miniGameIndex is sorted and build indexes are next to each other.
        return Random.Range(miniGameIndex[0], miniGameIndex[miniGameIndex.Count - 1]);
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
        Score = null;
        Application.Quit();

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
