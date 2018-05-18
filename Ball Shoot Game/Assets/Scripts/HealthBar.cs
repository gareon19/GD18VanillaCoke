using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject player;

    private float health;
    private float maxHealth;
    private Vector2 startScale;
    private Renderer rend;
    private int RGBvalue = 204;
    private float healthThreashhold = 0.5f;

    void Start() {
        maxHealth = player.GetComponent<PlayerController>().getHealth();
        startScale = transform.localScale;
        rend = GetComponent<SpriteRenderer>();
    }

	void Update () {
        if (player != null) {
            health = player.GetComponent<PlayerController>().getHealth();
            if (health < 0) {
                health = 0;
            }
            changeColor();
            if (player.tag == "Player 1") {
                scaleAndPositionBar(1f);
            } else {
                scaleAndPositionBar(-1f);
            }
        }
	}

    private void scaleAndPositionBar(float alignmentRL) {
        float originalValue = rend.bounds.min.x;
        // scale the health bar
        transform.localScale = new Vector2(startScale.x * health / maxHealth, startScale.y);
        float newValue = rend.bounds.min.x;
        float difference = newValue - originalValue;
        //move the bar to the alignment (left (1) or right (-1))
        transform.Translate(new Vector2(-difference*alignmentRL, 0f));
    }

    private void changeColor() {
        float redColorChange = health / maxHealth - healthThreashhold;
        float greenColorChange = 1 - (health / maxHealth) - healthThreashhold;
        if (redColorChange < 0) {
            redColorChange = 0;
        }
        if (greenColorChange < 0) {
            greenColorChange = 0;
        }
        Color newColor = new Color((RGBvalue - RGBvalue * (redColorChange) / (1-healthThreashhold)) / 255, 
                                   (RGBvalue - RGBvalue * (greenColorChange) / (1 - healthThreashhold)) / 255, 0);
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
}
