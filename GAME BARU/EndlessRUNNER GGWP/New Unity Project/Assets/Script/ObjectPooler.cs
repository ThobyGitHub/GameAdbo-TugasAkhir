using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Object pooler.
/// kelas ini dipakai untuk melakukan generate Object ground,
/// </summary>
public class ObjectPooler : MonoBehaviour {
	/// <summary>
	/// The pooled object.
	/// object yang akan digenerate. (ground)
	/// </summary>
	[SerializeField] private GameObject pooledObject;

	/// <summary>
	/// The pooled amount.
	/// jumlah object yang digenerate.
	/// </summary>
	[SerializeField] private int pooledAmount;

	private List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
	}

	/// <summary>
	/// Gets the pooled object.
	/// method untuk mengembalikan pooled object
	/// </summary>
	/// <returns>The pooled object.</returns>
	public GameObject GetPooledObject(){
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy) {
				return pooledObjects [i];
			}
		}
		GameObject obj = (GameObject) Instantiate (pooledObject);
		obj.SetActive (true);
		pooledObjects.Add (obj);
		return obj;
	}
}
