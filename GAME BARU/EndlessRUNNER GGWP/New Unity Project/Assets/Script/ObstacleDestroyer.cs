using UnityEngine;
using System.Collections;

/// <summary>
/// ObstacleDestroyer sebagai kelas untuk menghapus obstacle yang sudah dilewati
/// </summary>
public class ObstacleDestroyer : MonoBehaviour {
    /// <summary>
    /// atribut untuk menentukan letak obstacle di hapus
    /// </summary>
	[SerializeField] private GameObject obstacleDestructionPoint;

	// Use this for initialization
	void Start () {
		obstacleDestructionPoint = GameObject.Find ("ObstacleDestructionPoint");
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < obstacleDestructionPoint.transform.position.x) {
			Destroy (gameObject);
			gameObject.SetActive(false);
		}
	}
}
