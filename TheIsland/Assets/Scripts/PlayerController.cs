﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float verticalMovement;
    float horizontalMovement;
    public float moveSpeed = 500f;
    public float jumpForce = 500f;
    public float fallDecelerationFactor = 100f;
    public float jumpTime = 0.25f;
    public float jumpTimer = 0.25f;
    public Rigidbody2D rb;

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
    }

    private void OnTriggerStay2D(Collider2D collision) {
        onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        onGround = false;
    }

}
