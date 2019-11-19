using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMass : MonoBehaviour
{
    BoxCollider2D BoxCollider2D;
    void Start()
    {
        BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "liquid")
        {
            Debug.LogError("dziaua");
            col.gameObject.GetComponent<Rigidbody2D>().mass = 999999;
        }
    }
}
