using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownScript : MonoBehaviour {
    float timeLeft = 3;
    float currCountdownValue = 3;
    public TextMeshProUGUI countdownText;
    public GameObject countdownMenuUI;
    public GameObject player1;
    public GameObject player2;
    public BotController botController;

    // Use this for initialization
    void Start () {
        countdownMenuUI.SetActive(true);
        setPlayerControl(false);
        StartCoroutine(StartCountdown());

    }
	
	// Update is called once per frame
	void Update () {

        if (currCountdownValue <= 0) {
            setPlayerControl(true);
            countdownMenuUI.SetActive(false);
            if (botController != null) {
                botController.startBot = true;
            }
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 3)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            countdownText.text = "" + currCountdownValue;
        }
    }

    void setPlayerControl(bool canMoveAndShoot)
    {
        player1.GetComponent<PlayerController>().canMove = canMoveAndShoot;
        player1.GetComponent<PlayerController>().canShoot = canMoveAndShoot;

        player2.GetComponent<PlayerController>().canMove = canMoveAndShoot;
        player2.GetComponent<PlayerController>().canShoot = canMoveAndShoot;
    }
}
