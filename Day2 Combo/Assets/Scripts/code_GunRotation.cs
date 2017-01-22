using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_GunRotation : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
        Vector3 direction = target - playerPos;
        direction.Normalize();
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        //transform.Rotate(direction);
    }
}
