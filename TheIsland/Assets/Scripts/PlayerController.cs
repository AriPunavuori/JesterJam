using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float verticalMovement;
    float horizontalMovement;
    float moveSpeed = 150f;
    float jumpForce = 5000f;
    float fallDecelerationFactor = 300f;
    float jumpTime = 0.35f;
    float jumpTimer = 0.35f;
    Rigidbody2D rb;
    public GameObject banana;
    bool facingRight = true;
    Transform startPoint;
    GameManager gm;

    public bool onGround = false;
    public bool jumpButtonLifted;
    public Animator animator;


    private void Start() {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        startPoint = GameObject.Find("StartPoint").transform;
    }

    void Update() {

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        verticalMovement = Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(verticalMovement) < 0.1f) {
            jumpButtonLifted = true;
            animator.SetBool("IfJumping", true);
            jumpTimer = 0f;
            if(onGround) {
                jumpTimer = jumpTime;
                animator.SetBool("IfJumping", false);
            }

        }
        if(Input.GetButtonDown("Fire1")||Input.GetKeyDown(KeyCode.Space)) {
            if(banana != null) {
                gm.PlaySound(0);
                var bs =  banana.GetComponent<Banana>();
                bs.ThrowBanana(facingRight);
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
            facingRight = true;
        } else if(horizontalMovement < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
    }

    public void PlayerHit() {
        gm.PlaySound(1);
        gm.SetHealth(-1);
    }

}
