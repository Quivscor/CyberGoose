using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlatform : MonoBehaviour
{
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
    float used_time;
    bool flag = true;
    Gyroscope m_Gyro;
    float _gyro_offset;
    List<RandOff> bodies = new List<RandOff>();
    public float speed = 999999, z = 0;
    void Start()
    {
        var rigdigs = gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach (var item in rigdigs)
        {
            bodies.Add(new RandOff(item, item.position.x));
        }
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        Debug.Log(m_Gyro.attitude.z);
    }

    void Update()
    {

        if (flag)
        {
            used_time += Time.deltaTime;
            _gyro_offset = m_Gyro.attitude.eulerAngles.z;
            foreach (RandOff item in bodies)
            {
                Vector2 newPosition = Vector2.MoveTowards(new Vector2(item.rb2d.position.x, 0), new Vector2((m_Gyro.attitude.eulerAngles.z - _gyro_offset) *-0.3f + item.offset, 0), float.MaxValue);
                item.rb2d.MovePosition(newPosition);
            }
            if (used_time > 2)
            {
                flag = false;
                
            }
        }
        else
        {
            foreach (RandOff item in bodies)
            {
                Vector2 newPosition = Vector2.MoveTowards(new Vector2(item.rb2d.position.x,0), new Vector2((m_Gyro.attitude.eulerAngles.z - _gyro_offset) * -0.3f + item.offset, 0), float.MaxValue);
                item.rb2d.MovePosition(newPosition);
            }
        }

    }

    void OnGUI()
    {
        var euler = m_Gyro.attitude.eulerAngles;
        GUI.Label(new Rect(100, 300, 800, 800), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(100, 350, 800, 800), "Gyro x" + euler.x);
        GUI.Label(new Rect(100, 400, 800, 800), "Gyro y" + euler.y);
        GUI.Label(new Rect(100, 450, 800, 800), "Gyro z" + euler.z);
    }
}
