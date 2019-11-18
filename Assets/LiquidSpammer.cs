using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpammer : MonoBehaviour
{
    public GameObject liquid;
    public float respawn_speed=1;
    public float used_time;
    public float time_offset=1;
    void Start()
    {
        used_time -= time_offset;
    }

    // Update is called once per frame
    void Update()
    {
        used_time += Time.deltaTime;
        if(used_time>respawn_speed)
        {
            Instantiate(liquid, new Vector3(Random.value * 10-5, transform.position.y-1, 0), Quaternion.identity,this.transform);
            used_time = 0;
        }
        
    }
}
