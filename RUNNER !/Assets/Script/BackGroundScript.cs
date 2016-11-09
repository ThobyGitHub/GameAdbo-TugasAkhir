using UnityEngine;
using System.Collections;

public class BackGroundScript : MonoBehaviour {
	public float backgroundSize;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIdx;
	private int rightIdx;

	public float paralaxSpeed;
	private float lastCameraX;

	private void Start(){
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;

		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 
			layers [i] = transform.GetChild (i);

		leftIdx = 0;
		rightIdx = layers.Length - 1;

	}

	public void ScrollRight(){
		int lastLeft = leftIdx;
		layers [leftIdx].position = Vector3.right*(layers [rightIdx].position.x + backgroundSize);
		rightIdx = leftIdx;
		leftIdx++;
		if (leftIdx == layers.Length)
			leftIdx = 0;
	}

	public void ScrollLeft(){
		int lastRight = rightIdx;
		layers [rightIdx].position = Vector3.right*(layers [leftIdx].position.x - backgroundSize);
		leftIdx = rightIdx;
		rightIdx--;
		if (rightIdx < 0)
			rightIdx = layers.Length;
	}
	private void Update(){
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position+= Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTransform.position.x;


		if (cameraTransform.position.x < (layers [leftIdx].transform.position.x - viewZone))
			ScrollLeft ();
		if (cameraTransform.position.x > (layers [rightIdx].transform.position.x - viewZone))
			ScrollRight ();
	}

}
