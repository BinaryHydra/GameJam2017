using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_BackGround : MonoBehaviour {

    public float speed;
    public bool isNextImageCreated = false;
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
		if (this.transform.position.x <0 && !isNextImageCreated)
        {
            GameObject nextbackGround = Instantiate(gameObject);
            isNextImageCreated = true;
            nextbackGround.transform.position = new Vector3(transform.position.x + GetComponent<Renderer>().bounds.size.x, transform.position.y, transform.position.z);
            nextbackGround.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        if (this.transform.position.x < -30f)
            Destroy(this.gameObject);

    }
}
