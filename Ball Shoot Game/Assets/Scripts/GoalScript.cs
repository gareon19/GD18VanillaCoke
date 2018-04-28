using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    public PlayerController PlayerController;

    void OnCollisionEnter2D(Collision2D collObj)
    {
        switch (collObj.gameObject.tag)
        {
            case "Ball":
                PlayerController.takeDamage(40);
                Destroy(collObj.gameObject);
                break;
            default:
                break;
        }
    }
}
