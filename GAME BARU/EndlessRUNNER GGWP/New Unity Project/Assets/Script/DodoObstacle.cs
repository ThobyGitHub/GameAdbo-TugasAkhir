using UnityEngine;
using System.Collections;

public class DodoObstacle : MonoBehaviour,Obstacle {

	// Use this for initialization
	[SerializeField] private GameObject obstacle;

	private int idx;
	private Vector2 posNow;

	void Start () {
		posNow = GameObject.Find("Obstacle").transform.position;

	}

	// Update is called once per frame
	void Update () {
		posNow = new Vector2(GameObject.Find("Player").transform.position.x, 1.25f);

	}

	public void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Anda melewati sebuah obstacle :)");
		if (other.gameObject.name == "Player")
		{
			CreateObstacle();
		}
	}

	public void CreateObstacle()
	{	  
		posNow = new Vector2(posNow.x + Random.Range(40.7f, 50.7f), 1.25f-Random.Range(0f, 2.94f));
			//posNow = new Vector2(posNow.x + Random.Range(20, 30),transform.position.y );
			Instantiate(obstacle, posNow, Quaternion.identity);
		//posNow += Vector2.right * Random.Range(10, 20);
	}
}
