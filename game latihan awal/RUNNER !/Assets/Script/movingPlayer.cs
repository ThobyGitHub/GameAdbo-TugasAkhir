using UnityEngine;
using System.Collections;

public class movingPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private bool grounded;
    [SerializeField] private bool gameOver;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D myRigidBody;
    private Collider2D myCollider;
    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        this.grounded = true;
        this.gameOver = false;
        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveSpeed<100){
			moveSpeed+=0.3f;
		}
		grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                jumpSound.Play();
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }
        myAnimator.SetFloat("speed", myRigidBody.velocity.x);
        myAnimator.SetBool("grounded", grounded);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "New Sprite")
        {
            Debug.Log("TRIGGERED!");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "New Sprite")
        {
            this.myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            this.gameOver = true;
        }
    }
}