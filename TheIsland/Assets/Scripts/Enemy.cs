using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject ammoPrefab;
    float ammoSpawnInterval = 1;
    float ammoSpawnTimer;


    void Update() {
        ammoSpawnTimer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player"&& ammoSpawnTimer < 0) {
            Instantiate(ammoPrefab, transform.position, Quaternion.identity);
            ammoSpawnTimer = ammoSpawnInterval;
        }
    }
}
