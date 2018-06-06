using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject arrow_player_1;
    public GameObject arrow_player_2;
    public GameObject arrows_weapons_1;
    public GameObject arrow_player1_hp;
    public GameObject arrow_player2_hp;
    public GameObject arrow_ball;
    public GameObject arrow_goals;
    public GameObject weapons_player1;
    public GameObject weapons_player2;
    public GameObject ball;
    public BotController botController;

    // Use this for initialization
    void Start () {
        // TODO: workaround for missing ball

        RemovePlayerControl();
        StartTutorial();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void RemovePlayerControl() {
        player1.GetComponent<PlayerController>().canMove = false;
        player1.GetComponent<PlayerController>().canShoot = false;
    }

    void StartTutorial() {
        text1.SetActive(true);
        arrow_player_1.SetActive(true);
        Invoke("MoveInstructions", 3);
    }

    void MoveInstructions() {
        text1.SetActive(false);
        arrow_player_1.SetActive(false);
        text2.SetActive(true);
        player1.GetComponent<PlayerController>().canMove = true;
        StartCoroutine(WaitForPlayerMovement());
    }

    IEnumerator WaitForPlayerMovement() {
        Vector3 player_position = player1.transform.position;
        yield return new WaitUntil(() => Vector3.Distance(player_position, player1.transform.position) > 1);
        PlayerMoved();
    }

    void PlayerMoved() {
        text2.SetActive(false);
        text3.SetActive(true);
        weapons_player1.SetActive(true);
        arrows_weapons_1.SetActive(true);
        StartCoroutine(WaitForWeaponPickup());
    }

    IEnumerator WaitForWeaponPickup()
    {
        yield return new WaitUntil(() => player1.GetComponent<PlayerController>().pickedUpWeapon);
        PickedUpWeapon();
    }

    void PickedUpWeapon() {
        text3.SetActive(false);
        arrows_weapons_1.SetActive(false);
        player2.SetActive(true);
        text4.SetActive(true);
        arrow_player_2.SetActive(true);
        player1.GetComponent<PlayerController>().canShoot = true;
        StartCoroutine(WaitForEnemyDamage());
    }

    IEnumerator WaitForEnemyDamage()
    {
        yield return new WaitUntil(() => player2.GetComponent<PlayerController>().health < 100);
        ShotEnemy();
    }

    void ShotEnemy() {
        player1.GetComponent<PlayerController>().canShoot = false;
        player1.GetComponent<PlayerController>().canMove = false;
        text4.SetActive(false);
        arrow_player_2.SetActive(false);

        text5.SetActive(true);
        arrow_player2_hp.SetActive(true);

        Invoke("BotTutorialShot", 3);
    }

    void BotTutorialShot() {
        text5.SetActive(false);
        arrow_player2_hp.SetActive(false);
        weapons_player2.SetActive(true);

        botController.startBot = true;

        StartCoroutine(WaitForPlayerDamage());
    }

    IEnumerator WaitForPlayerDamage()
    {
        yield return new WaitUntil(() => player1.GetComponent<PlayerController>().health < 100);
        PlayerShot();
    }

    void PlayerShot() {
        text6.SetActive(true);
        arrow_player1_hp.SetActive(true);
        Invoke("SpawnBall", 3);
    }

    void SpawnBall() {
        text6.SetActive(false);
        arrow_player1_hp.SetActive(false);
        ball.SetActive(true);
        text7.SetActive(true);
        arrow_ball.SetActive(true);
        Invoke("ExplainBall", 3);
    }

    void ExplainBall() {
        text7.SetActive(false);
        arrow_ball.SetActive(false);
        text8.SetActive(true);
        arrow_goals.SetActive(true);
        Invoke("GameReady", 3);
    }

    void GameReady() {
        text8.SetActive(false);
        arrow_goals.SetActive(false);
        text9.SetActive(true);

        // start bot behavior when ready
        Invoke("BackToMainMenu", 3);
    }
    void BackToMainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
