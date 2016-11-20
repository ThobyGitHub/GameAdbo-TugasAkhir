using UnityEngine;
using System.Collections;
/// <summary>
/// BackgroundScrollScript adalah kelas untuk membuat background bergerak
/// </summary>
public class BackgroundScrollScript : MonoBehaviour {
    /// <summary>
    /// atribut offset sebagai parameter yang di gunakan untuk settextureoffset
    /// </summary>
    [SerializeField] private float offset;
    /// <summary>
    /// atribut speed untuk mengatur kecepatan bergerak layar nantinya
    /// </summary>
	[SerializeField] private float speed;

	// Update is called once per frame
	void Update () {
		offset = Time.time * 0.2f * speed;
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}
