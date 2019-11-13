using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinInTime : MonoBehaviour
{
    float time;
    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        rb2d.MoveRotation(time * 100);
    }
}
