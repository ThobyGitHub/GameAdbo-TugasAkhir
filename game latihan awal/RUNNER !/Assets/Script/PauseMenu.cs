using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;
	public void pause(){
		Time.timeScale = 0f;
		pauseMenu.gameObject.SetActive (true);
	}
	public void resume(){
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
	}
	public void backToMainMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main menu");
	}
	public void quit(){
		Application.Quit();
	}
}
