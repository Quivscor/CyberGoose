using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float spawnFreq;
    public float spawnOffset;
    private float spawnTime;

    public List<Food> foodList;

    private void Start()
    {
        spawnTime = spawnFreq - spawnOffset;
    }

    void FixedUpdate()
    {
        spawnTime -= Time.fixedDeltaTime;
        if (spawnTime <= 0)
            SpawnFood();
    }

    private void SpawnFood()
    {
        Food food = Instantiate<Food>(foodList[Random.Range(0, foodList.Count)], 
            this.transform.position, Quaternion.identity, this.transform);

        spawnTime = spawnFreq;
    }
}
