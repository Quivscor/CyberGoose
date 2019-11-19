using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchLiquid : MonoBehaviour
{
    public int maxLostLiquid = 3;
    public int currentLostLiquid;
    BoxCollider2D BoxCollider2D;
    void Start()
    {
        BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="liquid" )
        {
            currentLostLiquid++;
            Destroy(col.gameObject);
            if(currentLostLiquid==maxLostLiquid)
            {
                Destroy(GameObject.Find("LiquidSpammer"));
                GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnDefeat();
            }
        }
    }
   
}
