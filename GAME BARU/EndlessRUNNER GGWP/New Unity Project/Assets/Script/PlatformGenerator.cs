﻿using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	[SerializeField] private GameObject thePlatform;
	[SerializeField] private Transform generationPoint;
	[SerializeField] private float distanceBetween;

	private float platformWidth;

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
