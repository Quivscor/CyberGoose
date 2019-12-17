using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    public GameObject fork;
    public GameObject particle;
    bool loss = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            fork.transform.Translate(Vector3.left);
            particle.SetActive(true);
            StartCoroutine("Wait", 1);
        }
        if (loss)
            GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnDefeat();
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        loss = true;
        
    }
}
