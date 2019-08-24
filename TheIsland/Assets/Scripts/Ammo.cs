using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    float lifetime = 1;
    float speed = 10;
    Vector2 target;

    void Start() {
        var player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(lifetime < 0) {
            Destroy(gameObject);
        }
        lifetime -= Time.deltaTime;
    }
}
