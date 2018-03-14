using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
        movePlayer();
	}

    private void movePlayer() {


        //Vector3 direction = new Vector3(h, v, 0f).normalized;

        //transform.Translate(direction * speed * Time.deltaTime);
    }
}
