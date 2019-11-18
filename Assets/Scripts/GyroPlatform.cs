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
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        foreach (RandOff item in bodies)
        {
            Vector2 newPosition = Vector2.MoveTowards(item.rb2d.position, new Vector2(m_Gyro.attitude.z*-15 + item.offset,0), float.MaxValue);
            item.rb2d.MovePosition(newPosition);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 300, 800, 800), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(100, 350, 800, 800), "Gyro x" + m_Gyro.attitude.x);
        GUI.Label(new Rect(100, 400, 800, 800), "Gyro y" + m_Gyro.attitude.y    );
        GUI.Label(new Rect(100, 450, 800, 800), "Gyro z" + m_Gyro.attitude.z);
    }
}
