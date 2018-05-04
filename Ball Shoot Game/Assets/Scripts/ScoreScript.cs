using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour {

    public GameObject player;
    private TextMeshProUGUI scoreText;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "" + player.GetComponent<PlayerController>().getScoreValue();
    }
}
