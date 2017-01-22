using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_SpawnObjectRandom : MonoBehaviour
{
    public GameObject spawnObject;
    public float xPos;
    public float yPosInterval;
    public float minTimeRange;
    public float maxTimeRange;
    private float initTime;

    void Start()
    {
        initTime = Random.Range(minTimeRange, maxTimeRange);
    }

    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        initTime -= Time.deltaTime;
        if (initTime <= 0)
        {
            GameObject newObject = Instantiate(spawnObject);
            newObject.GetComponent<Transform>().position = new Vector2(xPos, Random.Range(yPosInterval, -yPosInterval));
            float randTimeInterval = Random.Range(minTimeRange, maxTimeRange);
            initTime = randTimeInterval;

        }
    }
}