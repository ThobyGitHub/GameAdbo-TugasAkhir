using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	public float speedMultiply;

	public float speedIncreaseMilestone;
	private float speedMilestoneCount;


	public float jumpForce;

	public bool isGround;
	public LayerMask whatIsGround;

	public float jumpTime;
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

		if (isGround) {
			jumpTimeCounter = jumpTime;
		}
		myAnimator.SetFloat ("MovingSpeed", myRigidBody.velocity.x);
		myAnimator.SetBool ("isGround", isGround);
	}

	void OnCollisionEnter2d(Collision2D other){
		if (other.gameObject.tag == "killBox") {
			theGameManager.RestartGame ();
		}
	}
}
