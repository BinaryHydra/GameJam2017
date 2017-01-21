using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_BulletSpawn : MonoBehaviour
{

    public GameObject target;
    public GameObject projectile;
    public float xPos;
    public float yPos;
    public float shootInterval;
    private float initTime;
    public void Start()
    { 
        initTime = shootInterval;
    }
    private void Update()
    {
        initTime -= Time.deltaTime;
        if (initTime <=0)
        {
            
            GameObject newBullet = Instantiate(projectile);
            newBullet.GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
            initTime = shootInterval;
        }
    }
}
