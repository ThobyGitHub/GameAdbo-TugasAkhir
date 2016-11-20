using UnityEngine;
using System.Collections;

/// <summary>
/// kelas BarrelObstacle merepresentasikan obstacle barrel
/// hal yang membedakan kelas ini dengan kelas obstacle yaitu posisi dari
/// transform.position.y yang tidak di random, seperti pada kelas dodoObstacle.
/// </summary>
public class BarrelObstacle : MonoBehaviour,Obstacle {

	/// <summary>
	/// The obstacle. obstacle-obstacle barrel dengan ukuran yang berbeda-beda.
	/// </summary>
	[SerializeField]private GameObject[] obstacle;

	/// <summary>
	/// The index. merupakan index/ iterator untuk setiap elemen dari array GameObject
	/// index ini akan di random nantinya untuk ukuran barrel yang berbeda
	/// </summary>
	private int idx;
	/// <summary>
	/// The position now. posisi dari obstacle , posisi ini akan di update,
	/// setiap kali player melewati sebuah obstacle, dan akan di generate di posNow 
	/// (pos selanjutnya).
	/// </summary>
	private Vector2 posNow;

	void Start()
	{
		posNow = GameObject.Find("Obstacle").transform.position;

	}

	// Update is called once per frame
	void Update()
	{
		posNow = new Vector2(GameObject.Find("Player").transform.position.x, -2.93f);

	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// saat terjadi trigger / collider dari player melewati collider dari obstacle,
	/// maka posNow akan diupdate untuk men generate obstacle baru di depan player.
	/// </summary>
	/// <param name="other">Other.
	/// other ini merupakan collider dari player.
	/// </param>
	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Anda melewati sebuah obstacle :)");
		if (other.gameObject.name == "Player")
		{
			CreateObstacle();
		}
	}

	/// <summary>
	/// method ini untuk membuat obstacle baru setelah obstacle di posisi posNow dilewati.
	/// </summary>
	public void CreateObstacle()
	{
		idx = Random.Range(0, obstacle.Length);
		if (idx == 1)
		{
			posNow = new Vector2(posNow.x + Random.Range(40.7f, 50.7f), -2.93f);
			Instantiate(obstacle[idx], posNow, Quaternion.identity);
		}
		else
		{
			posNow = new Vector2(posNow.x + Random.Range(40.7f, 50.7f),-2.93f );
			Instantiate(obstacle[idx], posNow, Quaternion.identity);
		}
	}
}
