using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    
	void Start () {
		
	}
	

	void Update () {
        movePlayer();
	}

    // moves the player
    private void movePlayer() {
        float moveHorizontal;
        float moveVertical;
        if (gameObject.tag == "Player 1") {
            moveHorizontal = Input.GetAxis("Horizontal-Player-1");
            moveVertical = Input.GetAxis("Vertical-Player-1");
        } else {
            moveHorizontal = Input.GetAxis("Horizontal-Player-2");
            moveVertical = Input.GetAxis("Vertical-Player-2");
        }

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0f).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
}
