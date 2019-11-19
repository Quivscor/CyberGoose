using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDelete : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
