using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_KatanaDespawn : MonoBehaviour {

   // Animator anim;
	void Start () {
         
       // anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Destroy(gameObject, 0.2f);
        //anim.SetTrigger("StopKatanaAttack");
    }
}
