using UnityEngine;
using System.Collections;
/// <summary>
/// GameGenerator sebagai kelas yang digunakan saat permainan berlangsung
/// </summary>
public class GameGenerator : MonoBehaviour {
    /// <summary>
    /// atribut untuk menentukan letak membuat platform
    /// </summary>
	[SerializeField] private Transform platformGenerator;
    /// <summary>
    /// atribut Vector3 sebagai titik awal yang harus dilewati untuk mulai membuat platform baru
    /// </summary>
	private Vector3 platformStartPoint;
    /// <summary>
    /// atribut untuk musik selama permainan berlangsung
    /// </summary>
	[SerializeField] private AudioSource themeMusic;
	 
    /// <summary>
    /// atribut karakter yang digunakan dengan PlayerController
    /// </summary>
	[SerializeField] private PlayerController thePlayer;
    /// <summary>
    /// atribut untuk menentukan posisi awal karakter saat awal permainan
    /// </summary>
	private Vector3 playerStartPoint;
    /// <summary>
    /// list untuk menghapus platform yang sudah dilewati
    /// </summary>
    private PlatformDestroyer[] platformList;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
        themeMusic.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (themeMusic.isPlaying == false) { themeMusic.Play(); }
	}
    /// <summary>
    /// RestartGame dengan tipe void untuk mengulang permainan
    /// </summary>
	public void RestartGame(){
		StartCoroutine ("RestartGameCo");
	}

    /// <summary>
    /// RestartGameCo method yang dipanggil saat restart game
    /// mengembalikan posisi karakter ke posisi awal game
    /// mengembalikan posisi platformstartpoint dan platformdestroyerpoint ke posisi awal
    /// </summary>
    /// <returns></returns>
	public IEnumerator RestartGameCo(){
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++) {
            platformList[i].gameObject.SetActive(false);
        }

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
	}



}
