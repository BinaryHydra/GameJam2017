using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_powerUPdash : MonoBehaviour {

    private Rigidbody2D powerUP;
    public float speed = 5.511f;

    void Start()
    {
        powerUP = gameObject.GetComponent<Rigidbody2D>();
        powerUP.velocity = (Vector2.left).normalized * speed;
    }
}
