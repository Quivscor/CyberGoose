﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(GameManager.Instance.GetNextMiniGame());
    }
}
