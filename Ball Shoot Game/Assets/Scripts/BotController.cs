using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour {
    bool gotWeapon = false;
    public bool startBot = false;
    bool tutorialShot = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gotWeapon && startBot) {
            pickWeapon();
        }
        if (gotWeapon && startBot && !tutorialShot)
        {
            warningShot();
        }
    }

    private void pickWeapon()
    {
        Vector3 direction = new Vector3(-1, 0, 0f).normalized;
        transform.Translate(direction * 5 * Time.deltaTime);
    }

    private void warningShot() {
        GetComponent<PlayerController>().shootBullets(false);
        tutorialShot = true;
    }

    void OnCollisionEnter2D(Collision2D collObj)
    {
        if (collObj.gameObject.tag != "Bullet") {
            gotWeapon = true;
        }
    }
}
