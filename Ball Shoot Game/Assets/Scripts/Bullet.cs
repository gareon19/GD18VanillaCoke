using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public float bulletSpeed;

    private Vector2 direction;

    public void setDirection(Vector2 direction) {
        this.direction = direction;
    }

    void Update () {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    } 

}
