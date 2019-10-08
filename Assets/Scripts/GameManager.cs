using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerScore score;

    public static GameManager Instance;
    void Start()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(this);
    }
}
