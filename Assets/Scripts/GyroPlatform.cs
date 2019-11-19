using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlatform : MonoBehaviour
{

    float used_time;
    bool flag = true;
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
        if (flag)
        {
            used_time += Time.deltaTime;
            if (used_time > 2)
            {
                flag = false;
            }
        }
        else
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
    // void OnGUI()
    // {
    //     var euler = m_Gyro.attitude.eulerAngles;
    //     GUI.Label(new Rect(100, 300, 800, 800), "Gyro rotation rate " + m_Gyro.rotationRate);
    //     GUI.Label(new Rect(100, 350, 800, 800), "Gyro x" + euler.x);
    //     GUI.Label(new Rect(100, 400, 800, 800), "Gyro y" + euler.y);
    //     GUI.Label(new Rect(100, 450, 800, 800), "Gyro z" + euler.z);
    // }
}
