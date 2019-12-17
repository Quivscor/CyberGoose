using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnector : MonoBehaviour
{
    private CableUnit[,] cables = new CableUnit[4,4];
    private void Start()
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                cables[i,j] = this.transform.GetChild(i * 4 + j).GetComponent<CableUnit>();
    }

    public void CheckWinCondition()
    {
        if (cables[0, 0].left && cables[0, 0].right)
            if (cables[0, 1].left && cables[0, 1].down)
                if (cables[1, 1].up && cables[1, 1].right)
                    if (cables[1, 2].left && cables[1, 2].right)
                        if (cables[1, 3].left && cables[1, 3].down)
                            if (cables[2, 3].up && cables[2, 3].down)
                                if (cables[3, 3].up && cables[3, 3].right)
                                {
                                    GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnWin();
                                }
    }
}
