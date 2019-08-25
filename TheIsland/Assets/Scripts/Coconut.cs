using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour {
    float startTime = .05f;
    float lifetime = 1;
    float speed = 15;
    bool coconutThrown;
    Vector2 target;
    Rigidbody2D rb;
    bool playerHit;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        startTime -= Time.deltaTime;
        if(startTime < 0) {
            lifetime -= Time.deltaTime;
            if(!coconutThrown) {
                ThrowCoconut();
                coconutThrown = true;
            }
        }
        if(lifetime < 0) {
            Destroy(gameObject);
        }
    }

    void ThrowCoconut() {
        var player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position - transform.position;
        rb.isKinematic = false;
        rb.AddForce(target * 2, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            var pc = collision.GetComponent<PlayerController>();
            if (!playerHit) {
                pc.PlayerHit();
                playerHit = true;
            }

        }
    }
}
