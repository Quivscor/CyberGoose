using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time = -1;
    // Start is called before the first frame update
    void Start()
    {
        if (time <= 0)
            Debug.Log("You're using it wrong, stupid");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if (time <= 0)
            Destroy(this.gameObject);
    }
}
