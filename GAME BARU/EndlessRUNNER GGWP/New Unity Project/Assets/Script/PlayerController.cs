﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	[SerializeField] private float moveSpeed;
	[SerializeField] private float speedMultiply;

	[SerializeField] private float speedIncreaseMilestone;
	private float speedMilestoneCount;


	[SerializeField] private float jumpForce;

	[SerializeField] private bool isGround;
	[SerializeField] private bool isBow;
	[SerializeField] private LayerMask whatIsGround;

	[SerializeField] private float jumpTime;
	private float jumpTimeCounter;

	private Rigidbody2D myRigidBody;
	private Collider2D myCollider;
	private Animator myAnimator;

	public GameGenerator theGameManager;


    // Use this for initialization
    void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
        this.isBow = false;
    }

    // Update is called once per frame
    void Update () {
		isGround = Physics2D.IsTouchingLayers (myCollider,whatIsGround);

		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiply;
			moveSpeed = moveSpeed * speedMultiply;
		}
		myRigidBody.velocity = new Vector2 (moveSpeed,myRigidBody.velocity.y);
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isGround) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
			}
		}
		if (Input.GetKey (KeyCode.Space)) {
			if (jumpTimeCounter > 0) { 
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			jumpTimeCounter = 0;
		}

        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.isBow = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            this.isBow = false;
        }

		if (isGround) {
			jumpTimeCounter = jumpTime;
		}
		myAnimator.SetFloat ("MovingSpeed", myRigidBody.velocity.x);
		myAnimator.SetBool ("isGround", isGround);
        myAnimator.SetBool("isBow", isBow);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Obstacle") {
            Debug.Log("Anda menabrak sebuah obstacle, game over!");
            //theGameManager.RestartGame ();
			FindObjectOfType<ScoreManager>().scoreIncreasing=false;
			SceneManager.LoadScene("Game Over");

		}
	}

   
}
