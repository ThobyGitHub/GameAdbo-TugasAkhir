using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
/// <summary>
/// PlayerController sebagai kelas untuk mengatur pergerakan player
/// </summary>
public class PlayerController : MonoBehaviour {
	/// <summary>
    /// atribut moveSpeed dengan tipe float sebagai kecepatan berjalannya karakter
    /// </summary>
	[SerializeField] private float moveSpeed;

    /// <summary>
    /// atribut speedMultiply dengan tipe float untuk mempercepat jalannya karakter
    /// </summary>
	[SerializeField] private float speedMultiply;

    /// <summary>
    /// atribut dengan tipe float sebagai batas kecepatan mulai bertambah
    /// </summary>
	[SerializeField] private float speedIncreaseMilestone;

    /// <summary>
    /// atribut untuk menyimpan jarak saat kecepatan bertambah
    /// </summary>
	private float speedMilestoneCount;

    /// <summary>
    /// atribut jumpForce untuk menentukan tinggi karakter lompat
    /// </summary>
	[SerializeField] private float jumpForce;

    /// <summary>
    /// atribut isGround untuk mengetahui karakter sedang berada di tanah
	/// true jika ya, dan false jika tidak.
    /// </summary>
	[SerializeField] private bool isGround;

    /// <summary>
    /// atribut isBow digunakan untuk mengetahui jika karakter sedang menunduk.
	/// true jika ya, dan false jika tidak.
    /// </summary>
	[SerializeField] private bool isBow;

    /// <summary>
    /// atribut whatIsGround untuk mengetahui layer mana yang ground
    /// </summary>
	[SerializeField] private LayerMask whatIsGround;

    /// <summary>
    /// atribut jumpTime untuk waktu karakter di udara
    /// </summary>
	[SerializeField] private float jumpTime;

    /// <summary>
    /// 
    /// </summary>
	private float jumpTimeCounter;

    /// <summary>
    /// atribut jumpSound untuk suara yang digunakan saat karakter lompat
    /// </summary>
    [SerializeField] private AudioSource jumpSound;

    /// <summary>
    /// atribut myRigidBody dengan tipe Rigidbody2D
    /// </summary>
	private Rigidbody2D myRigidBody;

    /// <summary>
    /// atribut myCollider dengan tipe Collider2D
    /// </summary>
	private Collider2D myCollider;

    /// <summary>
    /// atribut boxCollider dengan tipe BoxCollider2D
    /// </summary>
    private BoxCollider2D boxCollider;

    /// <summary>
    /// atribut myAnimator untuk animasi karakter
    /// </summary>
	private Animator myAnimator;


    // Use this for initialization
    void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
        this.isBow = false;
        this.boxCollider= GetComponent<BoxCollider2D>();
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
                jumpSound.Play();
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
            this.boxCollider.size = new Vector2(0.4609375f, 0.3f);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            this.isBow = false;
            this.boxCollider.size = new Vector2(0.4609375f, 0.53125f);
        }

		if (isGround) {
			jumpTimeCounter = jumpTime;
		}
		myAnimator.SetFloat ("MovingSpeed", myRigidBody.velocity.x);
		myAnimator.SetBool ("isGround", isGround);
        myAnimator.SetBool("isBow", isBow);
	}

    /// <summary>
    /// OnCollisionEnter2D dengan tipe void digunakan saat karakter menabrak obstacle atau game over
    /// </summary>
    /// <param name="other"></param>
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Obstacle") {
            Debug.Log("Anda menabrak sebuah obstacle, game over!");
			FindObjectOfType<ScoreManager>().setscoreIncreasing(false);
			SceneManager.LoadScene("Game Over");

		}
	}

   
}
