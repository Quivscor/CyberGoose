using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool goodFood;

    public GameObject particleEffect;

    #region Arc Trajectory Data
    protected Vector3 startPosition;
    protected Vector3 initialVelocity;

    public float height;
    public float gravity;
    public float time;
    protected float currentTime = 0;
    #endregion

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = CalculateVelocity(GameObject.Find("Mouth").transform.position, this.transform.position, 2);
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceX = distance;
        distanceX.y = 0;

        float Sy = distance.y;
        float Sx = distanceX.magnitude;

        float Vx = Sx / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceX.normalized;
        result *= Vx;
        result.y = Vy;

        return result;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit player!");
            MouthController player = collision.GetComponent<MouthController>();
            if((player.state == MouthController.MouthState.Open && !goodFood) ||
                (player.state == MouthController.MouthState.Closed && goodFood))
            {
                GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnDefeat();
            }

            if(player.state == MouthController.MouthState.Open)
            {
                Instantiate<GameObject>(particleEffect, this.transform.position - Vector3.up, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
