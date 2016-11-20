using UnityEngine;
using System.Collections;
/// <summary>
/// CameraController adalah kelas untuk mengatur pergerakan camera saat game dijalankan
/// </summary>
public class CameraController : MonoBehaviour {
    /// <summary>
    /// atribut thePlayer sebagai karakter yang digunakan dengan tipe PlayerController
    /// </summary>
	[SerializeField] private PlayerController thePlayer;

    /// <summary>
    /// atribut lastPlayerPosition dengan tipe Vector3 untuk menyimpan posisi terakhir karakter berada
    /// </summary>
	private Vector3 lastPlayerPosition;

	private float distanceToMove;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPosition = thePlayer.transform.position;
	}
}
