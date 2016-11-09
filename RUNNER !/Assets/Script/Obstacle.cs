using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
    public GameObject[] obstacle;
    public Transform cam;
	// Use this for initialization
	void Start () {
        ObstacleMaker();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * PlayerPrefs.GetInt("Speed") * Time.deltaTime);
    }

    void ObstacleMaker()
    {
        GameObject clone = (GameObject)Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position, Quaternion.identity);
        clone.name = "Quad";
        clone.AddComponent<BoxCollider2D>();
        clone.GetComponent<BoxCollider2D>().isTrigger = true;
        float xx = Random.Range(1, 5);
        Invoke("ObstacleMaker", xx);
    }
}
