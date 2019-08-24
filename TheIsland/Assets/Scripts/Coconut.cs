using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour {
    float startTime = .1f;
    float lifetime = 1;
    float speed = 10;
    bool coconutThrown;
    Vector2 target;
    Rigidbody2D rb;



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
        print("Cononut liftoff");
        var player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position - transform.position;
        print(target);
        rb.isKinematic = false;
        rb.AddForce(target * 2, ForceMode2D.Impulse);
    }
}
