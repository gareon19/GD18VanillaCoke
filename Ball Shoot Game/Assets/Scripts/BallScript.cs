using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Vector2 direction;
    public float ballSpeed;
    private Collider2D ballCollider;
    public GameObject[] ignoreCollision;
    public Rigidbody2D rigidBody;

    void Start () {
        direction = new Vector2(0, 0);
        rigidBody = GetComponent<Rigidbody2D>();
        ballCollider = GetComponent<CircleCollider2D>();
        // Todo: add checks / other collision components
        foreach(GameObject e in ignoreCollision){
           Physics2D.IgnoreCollision(e.GetComponent<BoxCollider2D>(), ballCollider);
        };

    }

    void Update () {
        	
	}


    void OnCollisionEnter2D(Collision2D collObj){
        Debug.Log(collObj.gameObject.tag);
        switch (collObj.gameObject.tag) {
            case "Bullet":
                // Todo: check if normalized is needed 
                direction = collObj.gameObject.GetComponent<BulletScript>().getDirection().normalized;
                rigidBody.velocity = (direction * ballSpeed);
                Destroy(collObj.gameObject);
                break;
            default:
                break;    
        }
    }

}
