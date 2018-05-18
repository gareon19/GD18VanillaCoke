using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Vector2 collDirection;
    public float ballSpeed;
    private Collider2D ballCollider;
    public GameObject[] ignoreCollision;
    public Rigidbody2D rigidBody;
    public Vector2 contactPoint;
    public Vector2 ballPosition;

    void Start () {
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
        switch (collObj.gameObject.tag) {
            case "Bullet":
                contactPoint = collObj.contacts[0].point;
                ballPosition.x = this.transform.position.x;
                ballPosition.y = this.transform.position.y;
                collDirection = ballPosition - contactPoint;
                collDirection.Normalize();
                rigidBody.velocity = (collDirection * ballSpeed);
                Destroy(collObj.gameObject);
                break;
            default:
                break;    
        }
    }

    public void setVelocity(Vector2 velocity) {
        rigidBody.velocity = velocity;
    }

}
