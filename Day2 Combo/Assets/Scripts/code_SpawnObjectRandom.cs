using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_SpawnObjectRandom : MonoBehaviour
{

    public GameObject spawnObject;
    public float xPos;
    public float yPosInterval;
    public float timeInterval;
    private float initTime;
    // Use this for initialization
    void Start()
    {
        initTime = timeInterval;
    }

    // Update is called once per frame
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
            initTime = timeInterval;

        }
    }
}
