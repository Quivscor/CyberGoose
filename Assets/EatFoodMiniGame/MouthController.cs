using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    public enum MouthState
    {
        Open,
        Closed
    }
    public MouthState state = MouthState.Closed;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            state = MouthState.Open;
            this.transform.localScale = new Vector3(0.65f, 2, 1);
        }
        else
        {
            state = MouthState.Closed;
            this.transform.localScale = new Vector3(0.65f, 1, 1);
        }

    }
}
