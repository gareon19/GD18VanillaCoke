using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateHandler;

public class BotController : MonoBehaviour {
    public bool startTutorial = false;
    public bool startBot = false;
    public bool gotWeapon = false;
    public PlayerController player1;
    public GameObject ball;
    public float playerDistanceX = 1f;
    public float ballDistanceX = 0f;

    public StateMachine<BotController> StateMachine { get; set; }

    void Start()
    {
        StateMachine = new StateMachine<BotController>(this);
        StateMachine.ChangeState(StateIdle.Instance);

        GetComponent<PlayerController>().canMove = false;
        GetComponent<PlayerController>().canShoot = false;
    }

    void Update()
    {

        StateMachine.Update();
    }

    void OnCollisionEnter2D(Collision2D collObj)
    {
        if (collObj.gameObject.tag == "Weapon")
        {
            Debug.Log("collided with weapon");
            gotWeapon = true;
        }
    }
}
