using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    
    public float shootingRate;
    public float reloadTime;
    public float bulletsUntilReload;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player 1" || coll.gameObject.tag == "Player 2") {
            coll.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            coll.gameObject.GetComponent<PlayerController>().setWeaponStats(shootingRate, reloadTime, bulletsUntilReload);
            coll.gameObject.GetComponent<PlayerController>().setBulletSprite(gameObject.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

}
