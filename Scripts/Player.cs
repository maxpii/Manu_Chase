using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private  float jumpForce = 11f;

    private float movementX;
    private float movementY;
    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";   
    private string GROUND_TAG = "Ground";
    Boolean walkOrNot = false; 
    
    private Boolean isGrounded = true;
    private string ENEMY_TAG = "Enemy";
    private void Awake() {

    }
    void Start()
    {

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        
    }

    // called every specific time not frame
    // used for physics
    private void FixedUpdate() {
        PlayerJump();
    }

    void PlayerMoveKeyboard() {
        //GetAxisRaw: returns -1 or 1 for a key and d key respectively. No press is 0
        // GetAxis: builds up to or accelerates to -1 or 1, otherwise similar to raw
        movementX = Input.GetAxis("Horizontal");
       //movementY = Input.GetAxis("Vertical");
        /*if (movementX != 0) {
            Debug.Log("move X value is: " + movementX);
        }*/
        // Time.deltaTime : time between each frame, about 1/60 frames per second. Very small
        // moveForce: our own value
        // only have new Vector3(arguments) would make us go crazy fast
       transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
       Debug.Log(transform.position);
       //transform.position += new Vector3(movementY, 0f, 0f) * Time.deltaTime * moveForce;


    }
    void AnimatePlayer() {
        if (movementX > 0) {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;
        }
        else if (movementX < 0) {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = true;
        }
        else {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }
    void PlayerJump() {
        // platform neutral, works on PC, console, mobile, etc
        // returns true when player presses (or holds depending on method) the jump button
        // spacebar on PC
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(this.gameObject); // this is player btw
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(ENEMY_TAG)) Destroy(gameObject);
    }

} // class
