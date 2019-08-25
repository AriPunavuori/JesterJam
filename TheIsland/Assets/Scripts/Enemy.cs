using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject ammoPrefab;
    public float ammoSpawnInterval = 1;
    public float ammoSpawnTimer;
    public float eatingBananaTime = 5f;
    public float throwDistance = 15f;
    bool shouldThrowCoconut;
    GameObject player;
    GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if(Vector2.Distance(player.transform.position, transform.position) < throwDistance) {
            shouldThrowCoconut = true;
        } else {
            shouldThrowCoconut = false;
        }
        ammoSpawnTimer -= Time.deltaTime;
        if(shouldThrowCoconut) {
            if(ammoSpawnTimer < 0) {
                ThrowCoconut();
            }
        }
    }

    void ThrowCoconut() {
        Instantiate(ammoPrefab, transform.position, Quaternion.identity);
        ammoSpawnTimer = ammoSpawnInterval;
        gm.PlaySound(3);
    }

    public void EatBanana() {
        ammoSpawnTimer = eatingBananaTime;
        gm.PlaySound(2);
    }
}
