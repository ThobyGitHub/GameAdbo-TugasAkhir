using UnityEngine;
using System.Collections;

public class BackgroundScrollScript : MonoBehaviour {

	float offset;
	public float speed;

	// Update is called once per frame
	void Update () {
		offset = Time.time * 0.2f * speed;
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}
