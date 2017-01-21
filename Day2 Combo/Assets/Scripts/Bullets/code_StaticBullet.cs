using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_StaticBullet : MonoBehaviour {

    private Rigidbody2D bullet;
    public float speed = 10;

    void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody2D>();
        bullet.velocity = (Vector2.left).normalized * speed;
    }
}
