using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnector : MonoBehaviour
{
    private CableUnit[,] cables = new CableUnit[3,3];

    private int variants = 3;
    private int variant;
    private void Start()
    {
        variant = Random.Range(0, variants);

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                cables[i,j] = this.transform.GetChild(i * 3 + j).GetComponent<CableUnit>();

        if(variant == 0)
        {
            cables[0, 0].SetStartConnections(0);
            cables[0, 1].SetStartConnections(3);
            cables[0, 2].SetStartConnections(6);
            cables[1, 0].SetStartConnections(0);
            cables[1, 1].SetStartConnections(4);
            cables[1, 2].SetStartConnections(2);
            cables[2, 0].SetStartConnections(1);
            cables[2, 1].SetStartConnections(5);
            cables[2, 2].SetStartConnections(7);
        }
        else if(variant == 1)
        {
            cables[0, 0].SetStartConnections(6);
            cables[0, 1].SetStartConnections(0);
            cables[0, 2].SetStartConnections(2);
            cables[1, 0].SetStartConnections(0);
            cables[1, 1].SetStartConnections(5);
            cables[1, 2].SetStartConnections(2);
            cables[2, 0].SetStartConnections(4);
            cables[2, 1].SetStartConnections(9);
            cables[2, 2].SetStartConnections(0);
        }
        else if(variant == 2)
        {
            cables[0, 0].SetStartConnections(2);
            cables[0, 1].SetStartConnections(3);
            cables[0, 2].SetStartConnections(2);
            cables[1, 0].SetStartConnections(9);
            cables[1, 1].SetStartConnections(6);
            cables[1, 2].SetStartConnections(7);
            cables[2, 0].SetStartConnections(4);
            cables[2, 1].SetStartConnections(3);
            cables[2, 2].SetStartConnections(4);
        }
    }

    public void CheckWinCondition()
    {
        switch(variant)
        {
            case 0:
                if(cables[0, 0].left && cables[0, 0].right &&
                    cables[0, 1].left && cables[0, 1].down &&
                    cables[1,1].up && cables[1,1].right &&
                    cables[1,2].left && cables[1,2].down &&
                    cables[2,2].up && cables[2,2].right)
                {
                    GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnWin();
                }
                break;
            case 1:
                if(cables[0,0].left && cables[0,0].down &&
                    cables[1,0].up && cables[1,0].down &&
                    cables[2,0].up && cables[2,0].right &&
                    cables[2,1].left && cables[2,1].right &&
                    cables[2,2].left && cables[2,2].right)
                {
                    GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnWin();
                }
                else if(cables[0, 0].left && cables[0,0].right &&
                    cables[0,1].left && cables[0,1].right &&
                    cables[0, 2].left && cables[0,2].down &&
                    cables[1,2].up && cables[1,2].left &&
                    cables[1,1].right && cables[1,1].down &&
                    cables[2,1].up && cables[2,1].right &&
                    cables[2, 2].left && cables[2, 2].right)
                {
                    GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnWin();
                }
                break;
            case 2:
                if(cables[0,0].left && cables[0,0].down &&
                    cables[1, 0].up && ((cables[1,0].right && 
                    cables[1,1].left && cables[1,1].right &&
                    cables[1,2].left && cables[1,2].down &&
                    cables[2,2].up && cables[2,2].right) ||
                    (cables[1,0].down && cables[2,0].up &&
                    cables[2,0].right && cables[2,1].left &&
                    cables[2,1].up && cables[1,1].down &&
                    cables[1,1].up && cables[0,1].down &&
                    cables[0,1].right && cables[0,2].left &&
                    cables[0,2].down && cables[1,2].up &&
                    cables[1,2].down && cables[2,2].up &&
                    cables[2,2].right)))
                {
                    GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnWin();
                }
                break;
        }
    }
}
