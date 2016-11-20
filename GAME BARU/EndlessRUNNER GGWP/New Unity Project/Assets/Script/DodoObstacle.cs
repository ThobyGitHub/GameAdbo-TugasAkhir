using UnityEngine;
using System.Collections;

/// <summary>
/// Dodo obstacle. kelas ini merupakan kelas untuk obstacle burung "dodo",
/// kelas ini dibedakan dengan obstacle barrel karena posisi.y dari burung
/// akan random, untuk mempersulit permainan,
/// dengan kata lain, burung dapat terbang tinggi / rendah
/// </summary>
public class DodoObstacle : MonoBehaviour,Obstacle {
	/// <summary>
	/// The obstacle.
	/// obstacle yang dimaksudkan adalah burung dodo.
	/// </summary>
	[SerializeField] private GameObject obstacle;

	private Vector2 posNow;
	// Use this for initialization
	void Start () {
		posNow = GameObject.Find("Obstacle").transform.position;
	}

	// Update is called once per frame
	void Update () {
		posNow = new Vector2(GameObject.Find("Player").transform.position.x, 1.25f);
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// method ini bertujuan ketika player melewati obstacle burung (trigger),
	/// maka obstacle burung akan dibuat di depan player kembali, (di generate)
	/// </summary>
	/// <param name="other">Other.
	/// other yang menjadi parameter merupakan collider dari player.
	/// </param>
	public void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Anda melewati sebuah obstacle :)");
		if (other.gameObject.name == "Player")
		{
			CreateObstacle();
		}
	}

	/// <summary>
	/// Creates the obstacle.
	/// method ini untuk membuat obstacle burung baru .
	/// </summary>
	public void CreateObstacle()
	{	  
		posNow = new Vector2(posNow.x + Random.Range(40.7f, 50.7f), 1.25f-Random.Range(0f, 2.94f));
			Instantiate(obstacle, posNow, Quaternion.identity);
	}
}
