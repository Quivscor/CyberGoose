using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlatform : MonoBehaviour
{
    List<RandOff> bodies = new List<RandOff>();
    void Start()
    {
        var rigdigs = gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach (var item in rigdigs)
        {
            bodies.Add(new RandOff(item, item.position.x));
        }
        Debug.Log(Input.acceleration.x);
    }

    void Update()
    {
        var v2 = new Vector2(LowPassFilterExample.OnUpdate().x * 25, 0);
        if (Mathf.Abs(transform.position.x + v2.x) < 6)
        {
            foreach (RandOff item in bodies)
            {
                var v22 = v2;
                v22.x += item.offset;
                item.rb2d.MovePosition(v22);
            }
        }
    }
    struct RandOff
    {
        public Rigidbody2D rb2d;
        public float offset;

        public RandOff(Rigidbody2D rb2d, float offset)
        {
            this.rb2d = rb2d;
            this.offset = offset;
        }
    }
}
