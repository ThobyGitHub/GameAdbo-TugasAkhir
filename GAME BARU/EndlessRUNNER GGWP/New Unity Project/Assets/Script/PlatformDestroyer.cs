using UnityEngine;
using System.Collections;

/// <summary>
/// PlatformDestroyer sebagai kelas untuk menghapus platform tempat karakter berjalan
/// </summary>
public class PlatformDestroyer : MonoBehaviour {
    /// <summary>
    /// Atribut platformDestructionPoint dengan tipe GameObject untuk menentukan platform mana yang harus di hapus
    /// </summary>
	[SerializeField] private GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
		platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformDestructionPoint.transform.position.x) {
			//Destroy (gameObject);
			gameObject.SetActive(false);
		}
	}
}
