using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float health;

    public float speed;
    public GameObject bullet;
    public GameObject bulletSpawn;

    public GameObject mainCanvas;

    private float shootingRate;
    private float reloadTime;
    private float bulletsUntilReload;
    private float[] bulletsShotsAtOnceWithAngle;

    private float nextBullet;
    private float bulletsFired;
    private bool reloading = false;

    private bool victory = false;


    void Start() {
        // :)
    }


    void Update() {
        // there might be a more efficient way
        if (!victory) {
            movePlayer();
            shooting();
            checkHealth();
        }
    }

    public void setWeaponStats(float shootingRate, float reloadTime, float bulletsUntilReload, float[] bulletsShotsAtOnceWithAngle) {
        this.shootingRate = shootingRate;
        this.reloadTime = reloadTime;
        this.bulletsUntilReload = bulletsUntilReload;
        this.bulletsShotsAtOnceWithAngle = bulletsShotsAtOnceWithAngle;
    }

    public void setBulletSpriteAndScale(Sprite sprite, Vector2 bulletScale) {
        bullet.GetComponent<SpriteRenderer>().sprite = sprite;
        bullet.transform.localScale = new Vector2(bulletScale.x * gameObject.transform.localScale.x,
                                                  bulletScale.y * gameObject.transform.localScale.y);
    }

    public float getHealth() {
        return health;
    }

    public int getScoreValue() {
        if (gameObject.tag == "Player 1") {
            return PlayerPrefs.GetInt("Player 1 Score");
        } else {
            return PlayerPrefs.GetInt("Player 2 Score");
        }
    }

    public void takeDamage(int damage) {
        health -= damage;
    }
    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
            case "Bullet":
                Destroy(coll.gameObject);
                health -= 10;
                break;
            case "Ball":
                health -= 20;
                break;
            default:
                break;
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
            shootBullets(true);
        } else if (gameObject.tag == "Player 2" && Input.GetButton("Fire1-Player-2") && Time.time > nextBullet) {
            shootBullets(false);
        }
    }

    private void shootBullets(bool shootRight) {
        if (shootingRate == 0) {
            return;
        }
        for (int i = 0; i< bulletsShotsAtOnceWithAngle.Length; i++) {
            Vector2 direction;
            // adapt bullet angle
            if (shootRight) {
                direction = Quaternion.AngleAxis(bulletsShotsAtOnceWithAngle[i], Vector3.forward) * Vector2.right;
            } else {
                direction = Quaternion.AngleAxis(bulletsShotsAtOnceWithAngle[i], Vector3.forward) * Vector2.left;
            }
            shootBullet(direction);
        }
    }

    private void shootBullet(Vector2 direction) {
        if (!reloading) {
            bulletsFired++;
            GameObject newBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            newBullet.GetComponent<BulletScript>().setDirection(direction);
            nextBullet = Time.time + shootingRate;
            if (bulletsFired >= bulletsUntilReload && !reloading) {
                StartCoroutine(reload());
            }
        }
    }

    IEnumerator reload() {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        bulletsFired = 0;
    }

    private void checkHealth() {
        if (health <= 0) {
            if (gameObject.tag == "Player 1") {
                PlayerPrefs.SetInt("Player 2 Score", (PlayerPrefs.GetInt("Player 2 Score") + 1));
            } else {
                PlayerPrefs.SetInt("Player 1 Score", (PlayerPrefs.GetInt("Player 1 Score") + 1));
            }
            checkPlayerVictory();
        }
    }

    private void checkPlayerVictory() {
        bool player1Won = PlayerPrefs.GetInt("Player 1 Score") >= 3;
        bool player2Won = PlayerPrefs.GetInt("Player 2 Score") >= 3;

        if (player1Won && player2Won) {
            // draw
            victory = true;
            mainCanvas.GetComponent<PauseScript>().showVictory("DRAW!");
        } else if (player1Won) {

            // Player 1 won
            victory = true;
            mainCanvas.GetComponent<PauseScript>().showVictory("PLAYER 1 WON!");

        } else if (player2Won) {

            // Player 2 won
            victory = true;
            mainCanvas.GetComponent<PauseScript>().showVictory("PLAYER 2 WON!");

        } else {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

}
