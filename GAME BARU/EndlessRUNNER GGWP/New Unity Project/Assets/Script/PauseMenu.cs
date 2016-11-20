using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// PauseMenu kelas yang digunakan saat button pause diclick
/// </summary>
public class PauseMenu : MonoBehaviour {
    /// <summary>
    /// 
    /// </summary>
	[SerializeField] private GameObject pauseMenu;

    /// <summary>
    /// 
    /// </summary>
	public void pause(){
		Time.timeScale = 0f;
		pauseMenu.gameObject.SetActive (true);

    }
    /// <summary>
    /// 
    /// </summary>
	public void resume(){
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
    }
    /// <summary>
    /// 
    /// </summary>
	public void restart(){
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
		SceneManager.LoadScene ("GGWP");
		FindObjectOfType<GameGenerator> ().RestartGame ();
	}
    /// <summary>
    /// 
    /// </summary>
	public void backToMainMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main menu");
		pauseMenu.gameObject.SetActive (false);
	}
    /// <summary>
    /// 
    /// </summary>
	public void quit(){
		Application.Quit();
	}
}
