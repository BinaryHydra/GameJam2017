using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_PlayerMovement : MonoBehaviour {
    public GameObject player;
    private Vector3 playerPos;

    private void Start()
    {
        if(player != null)
        {
            playerPos = player.transform.position;
        }
    }

    private void FixedUpdate () {
        if(player != null)
        {
                playerPos = player.transform.position;

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if(playerPos.y > -4)
                {
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.211f);
                }
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if(playerPos.y < 4)
                {
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.211f);
                }
            }
        }
    }
}
