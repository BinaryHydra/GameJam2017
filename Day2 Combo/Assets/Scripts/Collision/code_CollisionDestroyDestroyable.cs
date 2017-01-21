using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_CollisionDestroyDestroyable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "DestroyableObject")
        {
            if(gameObject.tag != "Player")
            {
                Destroy(gameObject,0.001f);
            }
            Destroy(col.gameObject,0.001f);
        }
    }
}
