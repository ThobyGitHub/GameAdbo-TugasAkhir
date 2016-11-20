using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// PauseMenu kelas yang digunakan saat button pause diclick
/// </summary>
public class PauseMenu : MonoBehaviour {

	[SerializeField] private GameObject pauseMenu;

    /// <summary>
    /// method untuk menghentikan sementara permainan.
    /// </summary>
	public void pause(){
		Time.timeScale = 0f;
		pauseMenu.gameObject.SetActive (true);

    }
    /// <summary>
    /// method untuk melanjutkan permainan.
    /// </summary>
	public void resume(){
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
    }
    /// <summary>
    /// method untuk melakukan restart permainan.
    /// </summary>
	public void restart(){
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
		SceneManager.LoadScene ("GGWP");
		FindObjectOfType<GameGenerator> ().RestartGame ();
	}

    /// <summary>
    /// method untuk kembali ke main menu.
    /// </summary>
	public void backToMainMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main menu");
		pauseMenu.gameObject.SetActive (false);
	}

    /// <summary>
    /// method untuk keluar dari permainan.
    /// </summary>
	public void quit(){
		Application.Quit();
	}
}
