using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {
    public GameObject theGround;
    public Transform generationPoint;
    private float platformWidth;

	// Use this for initialization
	void Start () {
        platformWidth = theGround.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            Instantiate(theGround, transform.position, transform.rotation);
        }
	}
}
