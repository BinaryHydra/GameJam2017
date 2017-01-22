using System.Collections;
using UnityEngine;

public class code_Megalodon : MonoBehaviour {
    private int stateMode;
    private GameObject target;
    public GameObject rocketObject;
    private float rocketTimer;
    private bool pause = false;

    private float sharkX_Axis_Timer;
    private float sharkX_speed;

    private int maxY_Axis_Range;
    private float sharkY_speed;

    private int maxBossHealth;
    private int currentBossHealth;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        // stateMode (Attack types)
        // Follow Player and Shoot Rockets [0]
        target = GameObject.FindGameObjectWithTag("Player");
        stateMode = 2;
        rocketTimer = 3.2f;
        sharkX_Axis_Timer = 2.21f;
        sharkX_speed = 0.066f;

        // State 1 enraged Y movement
        sharkY_speed = 0.333f;
        maxY_Axis_Range = 5;

        maxBossHealth = 320;
        currentBossHealth = maxBossHealth;
    }

    void FixedUpdate () {
        if(target != null)
        {
            if (!pause)
            {
                getBossStateAndProceed();
            }

            // State 1 Y axis enraged fast movement
            if (stateMode == 1)
            {
                if (gameObject.transform.position.y > maxY_Axis_Range)
                {
                    sharkY_speed = sharkY_speed * -1;
                }
                else if (gameObject.transform.position.y < maxY_Axis_Range * -1)
                {
                    sharkY_speed = sharkY_speed * -1;
                }
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + sharkY_speed);
            }
        }
	}

    void getBossStateAndProceed()
    {
        switch (stateMode)
        {
            case 0:
                animator.SetTrigger("Chill");
                state0();
                break;
            case 1:
                animator.SetTrigger("Angry");
                pause = true;
                StartCoroutine(state1());
                break;
            case 2:
                onSpawnState();
                break;
        }
    }

    void state0()
    {
        if (sharkX_Axis_Timer > 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - sharkX_speed, gameObject.transform.position.y);
            sharkX_Axis_Timer -= Time.deltaTime;
        }else if (sharkX_Axis_Timer <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + sharkX_speed, gameObject.transform.position.y);
            sharkX_speed = sharkX_speed * -1;
            sharkX_Axis_Timer = 2.21f;

            // transition to state 2 randomly:
            if(sharkX_speed > 0)
            {
                int roll = Random.Range(0, 4);
                Debug.Log("Roll: " + roll);
                if (roll == 3)
                {
                    stateMode = 1;
                }
            }
            
        }

        if (gameObject.transform.position.y+0.5f < target.transform.position.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.050f);
        }
        else if (gameObject.transform.position.y-0.5f > target.transform.position.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.050f);
        }

        rocket();
    }

    // Megalodon State0 rocket spawner with random timer
    void rocket()
    {
        if (rocketTimer > 0) rocketTimer -= Time.deltaTime;
        if (rocketTimer < 0.5f) animator.SetTrigger("Angry");
        if (rocketTimer <= 0)
        {
            // Spawn rocket and reset timer
            Debug.Log("Rocket Spawn!");
            GameObject newBullet = Instantiate(rocketObject);
            newBullet.transform.position = gameObject.transform.position;

            rocketTimer = Random.Range(0.7f, 2f);
            animator.SetTrigger("Chill");
        }
    }

    IEnumerator state1()
    {
        yield return new WaitForSeconds(0.444f);
        GameObject newBullet = Instantiate(rocketObject);
        newBullet.transform.position = gameObject.transform.position;

        // from 8 to 16 rockets
        int randomCount = Random.Range(8, 17);
        for (int i=0; i<randomCount; i++)
        {
            float randomInterval = Random.Range(0.333f, 0.555f);
            yield return new WaitForSeconds(randomInterval);
            newBullet = Instantiate(rocketObject);
            newBullet.transform.position = gameObject.transform.position;
        }

        pause = false;
        stateMode = 0;
    }

    // State [2] Boss Creation
    void onSpawnState()
    {
        if(gameObject.transform.position.x >= 10)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.111f, gameObject.transform.position.y);
        } else {
            stateMode = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Boss Hit!");
            currentBossHealth--;
            Destroy(col.gameObject, 0.001f);
            if (currentBossHealth == 0) Destroy(gameObject, 0.001f);
        }
    }
}