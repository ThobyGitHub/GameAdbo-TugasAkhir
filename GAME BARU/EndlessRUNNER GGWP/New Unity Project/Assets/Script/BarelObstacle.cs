using UnityEngine;
using System.Collections;

public class BarelObstacle : MonoBehaviour {

    [SerializeField]private GameObject[] obstacle;

    private int idx;
    private Vector2 posNow;
    
    void Start()
    {
        posNow = GameObject.Find("Obstacle").transform.position;
		this.obstacle = new GameObject[2];
        
    }

    // Update is called once per frame
    void Update()
    {
		posNow = new Vector2(GameObject.Find("Player").transform.position.x, -2.93f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
			posNow = new Vector2(posNow.x + Random.Range(30, 50), -2.93f);
            //posNow = new Vector2(posNow.x + Random.Range(20, 30),transform.position.y );
            Instantiate(obstacle[idx], posNow, Quaternion.identity);
        }
        else
        {
			posNow = new Vector2(posNow.x + Random.Range(30, 50), -2.93f );
            //posNow = new Vector2(posNow.x + Random.Range(20, 30),transform.position.y );
            Instantiate(obstacle[idx], posNow, Quaternion.identity);
        }
        //posNow += Vector2.right * Random.Range(10, 20);
    }
}
