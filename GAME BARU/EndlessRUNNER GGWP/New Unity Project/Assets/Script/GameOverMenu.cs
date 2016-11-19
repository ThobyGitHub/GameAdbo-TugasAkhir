using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameOverMenu : MonoBehaviour {
	[SerializeField]private AudioSource gameOverMusic;
	void Start(){
		gameOverMusic.Play ();
	}
	public void restart(){
		SceneManager.LoadScene ("GGWP");
		FindObjectOfType<GameGenerator> ().RestartGame ();
	}

	public void backToMainMenu(){		
		SceneManager.LoadScene ("Main menu");
	}

	public void quit(){
		Application.Quit();
	}
}
