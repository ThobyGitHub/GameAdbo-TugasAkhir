using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;
	public void pause(){
		Time.timeScale = 0f;
		pauseMenu.gameObject.SetActive (true);
        FindObjectOfType<GameGenerator>().themeMusic.Pause();

    }
	public void resume(){
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
        FindObjectOfType<GameGenerator>().themeMusic.UnPause();
    }
	public void restart(){
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
		SceneManager.LoadScene ("GGWP");
		FindObjectOfType<GameGenerator> ().RestartGame ();
	}
	public void backToMainMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main menu");
		pauseMenu.gameObject.SetActive (false);
	}
	public void quit(){
		Application.Quit();
	}
}
