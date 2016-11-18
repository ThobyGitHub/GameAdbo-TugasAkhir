using UnityEngine;
using System.Collections;

public class GameGenerator : MonoBehaviour {
	public Transform platformGenerator;
	private Vector3 platformStartPoint;
    public AudioSource themeMusic;
    public AudioSource gameOverMusic;
	public PlayerController thePlayer;
	private Vector3 playerStartPoint;
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

	public void RestartGame(){
		StartCoroutine ("RestartGameCo");
	}

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
