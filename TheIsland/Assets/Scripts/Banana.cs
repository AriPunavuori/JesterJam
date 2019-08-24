using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour {
    public BananaPlant bp;
    bool bananaThrown;
    float speed = 10f;
    float lifetime = 2f;
    Vector2 target;
    PlayerController pc;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(bananaThrown) {
            lifetime -= Time.deltaTime;
            if(lifetime < 0) {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
 
        if(collision.tag == "Player" && !bananaThrown) {
            pc = collision.GetComponent<PlayerController>();
            if(pc.banana == null) {
                bp.TakeBanana();
                transform.position = collision.transform.position;
                transform.parent = collision.gameObject.transform;
                pc.banana = this.gameObject;
            }
        }
        if(collision.tag == "Enemy") {
            var es = collision.GetComponent<Enemy>();
            es.EatBanana();
            Destroy(gameObject);
        }
    }

    public void ThrowBanana() {
        transform.parent = null;
        pc.banana = null;
        rb.isKinematic = false;
        target = new Vector3(7.5f, 8.5f, 0);
        rb.AddForce(target, ForceMode2D.Impulse);
        bananaThrown = true;
    }
}
