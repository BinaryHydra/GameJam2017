using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_Level : MonoBehaviour
{
    public float levelTimeSeconds;
    public GameObject torpedoSpawner;
    public GameObject megalodonBoss;
    private bool bossSpawned = false;

    void Update()
    {
        if (levelTimeSeconds <= 0)
        {
            // Spawn boss and remove torpedo spawner
            Destroy(torpedoSpawner);
            if (!bossSpawned)
            {
                GameObject newMegalodonBoss = Instantiate(megalodonBoss);
                newMegalodonBoss.GetComponent<Transform>().position = new Vector2(20, Random.Range(-10, 10));
            }
            bossSpawned = true;


        }
        else if (levelTimeSeconds > 0)
        {
            levelTimeSeconds -= Time.deltaTime;
        }
    }
}