using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float health;

    public float speed;
    public GameObject bullet;
    public GameObject bulletSpawn;
    
    private float shootingRate;
    private float reloadTime;
    private float bulletsUntilReload;
    private float nextBullet;
    private float bulletsFired;
    private float waitingTime;
    
	void Start () {
        // :)
	}
	

	void Update () {
        movePlayer();
        shooting();
        checkHealth();
	}

    public void setWeaponStats(float shootingRate, float reloadTime, float bulletsUntilReload) {
        this.shootingRate = shootingRate;
        this.reloadTime = reloadTime;
        this.bulletsUntilReload = bulletsUntilReload;
    }

    public void setBulletSprite(Sprite sprite) {
        bullet.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public float getHealth() {
        return health;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Bullet") {
            Destroy(coll.gameObject);
            health -= 20;
        }
    }

    // moves the player
    private void movePlayer() {
        float moveHorizontal;
        float moveVertical;
        if (gameObject.tag == "Player 1") {
            moveHorizontal = Input.GetAxisRaw("Horizontal-Player-1");
            moveVertical = Input.GetAxisRaw("Vertical-Player-1");
        } else {
            moveHorizontal = Input.GetAxisRaw("Horizontal-Player-2");
            moveVertical = Input.GetAxisRaw("Vertical-Player-2");
        }

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0f).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // shoots bullets
    private void shooting() {
        if (gameObject.tag == "Player 1" && Input.GetButton("Fire1-Player-1") && Time.time > nextBullet) {
            shootBullet(1f, 0f);
        } else if (gameObject.tag == "Player 2" && Input.GetButton("Fire1-Player-2") && Time.time > nextBullet) {
            shootBullet(-1f, 0f);
        }
    }

    private void shootBullet(float directionX, float directionY) {
        if (shootingRate == 0) {
            return;
        } else if (bulletsFired >= bulletsUntilReload && reloadTime > 0) {
            waitingTime++;
            if (waitingTime >= reloadTime) {
                bulletsFired = 0;
                waitingTime = 0;
            }
        } else {
            bulletsFired++;
            GameObject newBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            newBullet.GetComponent<BulletScript>().setDirection(new Vector2(directionX, directionY));
        }
        nextBullet = Time.time + shootingRate;
    }

    private void checkHealth() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
