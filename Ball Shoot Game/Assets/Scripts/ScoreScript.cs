using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public GameObject player;
    public TextMeshPro scoreText;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.GetComponent<PlayerController>() != null && scoreText != null)
        {
            scoreText.text = "" + player.GetComponent<PlayerController>().getScoreValue();
        }
    }
}
