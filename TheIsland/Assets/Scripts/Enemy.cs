using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject ammoPrefab;
    public float ammoSpawnInterval = 1;
    public float ammoSpawnTimer;
    public float eatingBananaTime = 5f;
    bool shouldThrowCoconut;

    void Update() {
        ammoSpawnTimer -= Time.deltaTime;
        if(shouldThrowCoconut) {
            if(ammoSpawnTimer < 0) {
                ThrowCoconut();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player") {
            shouldThrowCoconut = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player") {
            shouldThrowCoconut = false;
        }
    }

    void ThrowCoconut() {
        Instantiate(ammoPrefab, transform.position, Quaternion.identity);
        ammoSpawnTimer = ammoSpawnInterval;
    }

    public void EatBanana() {
        ammoSpawnTimer = eatingBananaTime;
        print("Eating Banana");
    }
}
