using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    
    public float shootingRate;
    public float reloadTime;
    public float bulletsUntilReload;
    public float[] bulletsShotsAtOnceWithAngle;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player 1" || coll.gameObject.tag == "Player 2") {
            // change weapon sprite, scale and stats
            coll.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            coll.gameObject.transform.GetChild(1).transform.localScale = new Vector2(gameObject.transform.localScale.x / coll.gameObject.transform.localScale.x,
                                                                                     gameObject.transform.localScale.y / coll.gameObject.transform.localScale.y);
            coll.gameObject.GetComponent<PlayerController>().setWeaponStats(shootingRate, reloadTime, bulletsUntilReload, bulletsShotsAtOnceWithAngle);
            // change bullet sprite & scale
            coll.gameObject.GetComponent<PlayerController>().setBulletSpriteAndScale(gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite,
                                                                                     gameObject.transform.GetChild(0).transform.localScale);

            Destroy(gameObject.transform.parent.gameObject);
        }
    }

}
