using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    public PlayerController PlayerController;

    private GameObject ball;
    private Vector2 startPosition;
    private Quaternion startRotation;

    void Start() {
        ball = GameObject.FindGameObjectWithTag("Ball");
        startPosition = ball.transform.position;
        startRotation = ball.transform.rotation;
    }

void OnCollisionEnter2D(Collision2D collObj)
    {
        switch (collObj.gameObject.tag)
        {
            case "Ball":
                PlayerController.takeDamage(40);
                destroyAllBullets();
                ball.transform.position = startPosition;
                ball.GetComponent<BallScript>().setVelocity(new Vector2(0,0));
                break;
            default:
                break;
        }
    }

    private void destroyAllBullets() {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)  {
            Destroy(bullet);
        }
    }
}
