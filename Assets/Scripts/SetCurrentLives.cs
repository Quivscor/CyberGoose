using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCurrentLives : MonoBehaviour
{
    public Sprite lostLife;

    void Start()
    {
        int lives = GameManager.Instance.Lives;
        int maxLives = GameManager.StartingLives;
        for(int i = maxLives - 1; i >= lives; i--)
        {
            this.transform.GetChild(i).GetComponent<Image>().sprite = lostLife;
        }
    }
}
