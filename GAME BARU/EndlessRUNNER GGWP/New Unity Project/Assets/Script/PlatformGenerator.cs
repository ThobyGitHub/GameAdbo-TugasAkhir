using UnityEngine;
using System.Collections;
/// <summary>
/// PlatformGenerator sebagai kelas untuk membuat objek Platform tempat berjalannya karakter
/// </summary>
public class PlatformGenerator : MonoBehaviour {
    /// <summary>
    /// atribut untuk menunjukan objek mana yang akan dibuat 
    /// </summary>
	[SerializeField] private GameObject thePlatform;

    /// <summary>
    /// atribut untuk menentukan titik awal membuat objek
    /// </summary>
	[SerializeField] private Transform generationPoint;

    /// <summary>
    /// atribut untuk menentukan jarak antar platform
    /// </summary>
	[SerializeField] private float distanceBetween;

	private float platformWidth;

    /// <summary>
    /// atribut ObjectPooler untuk menentukan objek objek yang akan digunakan secara bergantian
    /// </summary>
	[SerializeField] private ObjectPooler theObjectPool;

	// Use this for initialization
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= generationPoint.position.x) { 
			transform.position = new Vector3 (transform.position.x+platformWidth+distanceBetween,transform.position.y,transform.position.z);
			//Instantiate (thePlatform, transform.position, transform.rotation);
			GameObject newPlatform = theObjectPool.GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
		}

	}
}
