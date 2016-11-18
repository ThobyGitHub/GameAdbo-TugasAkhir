using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private GameObject[] obstacle;

    private int idx;
    private Vector2 posNow;
	private float posY;
    void Start () {
        posNow = GameObject.Find("Obstacle").transform.position;
		posY = 1.25f;
    }
	
	// Update is called once per frame
	void Update () {
        posNow = new Vector2(GameObject.Find("Player").transform.position.x, posY);
		
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Anda melewati sebuah obstacle :)");
        if (other.gameObject.name == "Player")
        {
            CreateObstacle();
        }
    }

    void CreateObstacle()
    {
        idx = Random.Range(0, obstacle.Length);
        if (idx == 1)
        {
			posNow = new Vector2(posNow.x + Random.Range(20, 30), posY-Random.Range(0f, 2.63f));
			//posNow = new Vector2(posNow.x + Random.Range(20, 30),transform.position.y );
           Instantiate(obstacle[idx], posNow, Quaternion.identity);
        }
        else
        {
			posNow = new Vector2(posNow.x + Random.Range(20, 30), posY-Random.Range(0f, 2.63f));
			//posNow = new Vector2(posNow.x + Random.Range(20, 30),transform.position.y );
            Instantiate(obstacle[idx], posNow, Quaternion.identity);
        }
        //posNow += Vector2.right * Random.Range(10, 20);
    }
}
