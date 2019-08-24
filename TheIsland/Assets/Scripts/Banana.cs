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


    void Update() {
        if(bananaThrown) {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            lifetime -= Time.deltaTime;
            if(lifetime < 0) {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        print(collision);
        if(collision.tag == "Player") {
            
            pc = collision.GetComponent<PlayerController>();
            if(pc.banana == null) {
                bp.TakeBanana();
                transform.parent = collision.gameObject.transform;
                pc.banana = this.gameObject;
            }
            
        }
    }

    public void ThrowBanana() {
        pc.banana = null;
        transform.parent = null;
        target = transform.position + new Vector3(15, 15, 0);
        bananaThrown = true;
    }
}
