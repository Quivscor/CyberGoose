using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool goodFood;

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
        startPosition = this.transform.position;
        initialVelocity = InitialVelocity();
        if (float.IsNaN(initialVelocity.x))
        {
            initialVelocity = Vector3.zero;
            Debug.LogError("Target is higher than the archer's y position + projectile height. Spawn prevented.");
        }
    }

    protected Vector3 InitialVelocity()
    {
        Vector3 target = GameObject.Find("Mouth").transform.position;

        float displacementY = target.y - startPosition.y;
        float displacementX = target.x - startPosition.x;
        time = Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * height);
        Vector3 velocityX = new Vector3(displacementX / time, 0, 0);
        return velocityX + velocityY;
    }

    protected Vector3 Position(float time)
    {
        float x = startPosition.x + initialVelocity.x * time;
        float y = startPosition.y + initialVelocity.y * time + (gravity / 2) * time * time;
        return new Vector3(x, y);
    }

    protected void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        transform.SetPositionAndRotation(Position(currentTime), Quaternion.identity);
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
        }
    }
}
