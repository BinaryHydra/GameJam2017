using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_DeleteBullet : MonoBehaviour {
    private float despawnTimer;

    private void Start()
    {
        despawnTimer = 5.0f;
    }

    private void Update()
    {
        despawnTimer -= Time.deltaTime;
        if(despawnTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
