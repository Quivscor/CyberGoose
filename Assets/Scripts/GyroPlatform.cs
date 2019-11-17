using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    Gyroscope m_Gyro;
    float _gyro_offset;
    void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        _gyro_offset = m_Gyro.attitude.z;
        if(_gyro_offset<0)
        {
            _gyro_offset *= -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = new Vector3(-(m_Gyro.attitude.z)*15, 0, 0);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 300, 800, 800), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(100, 350, 800, 800), "Gyro x" + m_Gyro.attitude.x);
        GUI.Label(new Rect(100, 400, 800, 800), "Gyro y" + m_Gyro.attitude.y    );
        GUI.Label(new Rect(100, 450, 800, 800), "Gyro z" + m_Gyro.attitude.z);
    }
}
