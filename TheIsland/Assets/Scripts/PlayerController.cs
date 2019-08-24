using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float verticalMovement;
    float horizontalMovement;
    float moveSpeed = 500f;
    float jumpForce = 7500f;
    float fallDecelerationFactor = 350f;
    float jumpTime = 0.35f;
    float jumpTimer = 0.35f;
    Rigidbody2D rb;
    public GameObject banana;

    public bool onGround = false;
    public bool jumpButtonLifted;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        if(Mathf.Abs(verticalMovement) < 0.1f) {
            jumpButtonLifted = true;
            jumpTimer = 0f;
            if(onGround) {
                jumpTimer = jumpTime;
            }

        }
        if(Input.GetButtonDown("Fire1")) {
            if(banana != null) {
                var bs =  banana.GetComponent<Banana>();
                bs.ThrowBanana();
            }
        }
    }

    private void FixedUpdate() {
        MoveHorizontal();
        MoveVertical();
    }
        
    void MoveVertical() {

        if(verticalMovement > 0.1f && jumpTimer > 0){
            if(onGround && jumpButtonLifted) {
                rb.AddForce(new Vector2(0, jumpForce));
                onGround = false;
                jumpButtonLifted = false;
            }
            jumpTimer -= Time.fixedDeltaTime;
            rb.AddForce(new Vector2(0, fallDecelerationFactor));
        } else if(!onGround){
            rb.AddForce(new Vector2(0, -fallDecelerationFactor * 2));
        }
    }

    void MoveHorizontal() {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        Flip();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Environment") {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Environment") {
            onGround = false;
            if(jumpButtonLifted) {
                jumpTimer = 0f;
            }
        }
    }

    void Flip() {
        if(horizontalMovement > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        } else if(horizontalMovement < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void PlayerHit() {
        // Tee jotakin
        print("Player Hit!");
    }

}
