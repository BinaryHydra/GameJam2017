using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_Bullet01 : MonoBehaviour {
    private Transform target;
    private Rigidbody2D bullet;
    public float speed = 10;

    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bullet = gameObject.GetComponent<Rigidbody2D>();
        bullet.velocity = (target.position - transform.position).normalized * speed;
    }
}
