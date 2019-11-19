using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnDefeat();
        }
    }
}
