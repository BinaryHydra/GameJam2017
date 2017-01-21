using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_Megalodon : MonoBehaviour {
    private int stateMode;
    private GameObject target;
    public GameObject rocketObject;
    private float rocketTimer;

    private float sharkX_Axis_Timer;
    private float sharkX_speed;

    void Start()
    {
        // stateMode (Attack types)
        // Follow Player and Shoot Rockets [0]
        target = GameObject.FindGameObjectWithTag("Player");
        stateMode = 0;
        rocketTimer = 3.2f;
        sharkX_Axis_Timer = 2.21f;
        sharkX_speed = 0.066f;
    }

    void FixedUpdate () {
        getBossStateAndProceed();
	}

    void getBossStateAndProceed()
    {
        switch (stateMode)
        {
            case 0:
                state0();
                break;
            case 1:
                state1();
                break;
            case 2:
                state2();
                break;
        }
    }

    void state0()
    {
        if (sharkX_Axis_Timer > 0)
        {
            Debug.Log("Timer: " + sharkX_Axis_Timer);
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - sharkX_speed, gameObject.transform.position.y);
            sharkX_Axis_Timer -= Time.deltaTime;
        }else if (sharkX_Axis_Timer <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + sharkX_speed, gameObject.transform.position.y);
            sharkX_speed = sharkX_speed * -1;
            sharkX_Axis_Timer = 2.21f;

            // transition to state 2:
        }

        if(gameObject.transform.position.y < target.transform.position.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.050f);
        } else if (gameObject.transform.position.y > target.transform.position.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.050f);
        }

        rocket();
    }

    // Megalodon State0 rocket spawner with random timer
    void rocket()
    {
        if (rocketTimer > 0) rocketTimer -= Time.deltaTime;
        if (rocketTimer <= 0)
        {
            // Spawn rocket and reset timer
            Debug.Log("Rocket Spawn!");
            GameObject newBullet = Instantiate(rocketObject);
            newBullet.transform.position = gameObject.transform.position;

            rocketTimer = Random.Range(2.5f, 5f);
        }
    }

    void state1()
    {

        Debug.Log("Boss State 1");
    }

    void state2()
    {
        Debug.Log("Boss State 2");
    }
}
