using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// GameOverMenu sebagai kelas yang digunakan saat permainan berakhir atau kalah.
/// memiliki method untuk restart, back to main menu, dan quit
/// </summary>
public class GameOverMenu : MonoBehaviour {
    /// <summary>
    /// atribut suara yang digunakan saat kalah dari permainan
    /// </summary>
	[SerializeField]private AudioSource gameOverMusic;

	void Start(){
		gameOverMusic.Play ();
	}
    /// <summary>
    /// restart dengan tipe void untuk mengulang permainan
    /// </summary>
	public void restart(){
		SceneManager.LoadScene ("GGWP");
		FindObjectOfType<GameGenerator> ().RestartGame ();
	}

    /// <summary>
    /// backToMainMenu dengan tipe void untuk kembai ke mainmenu
    /// </summary>
	public void backToMainMenu(){		
		SceneManager.LoadScene ("Main menu");
	}

    /// <summary>
    /// quit dengan tipe void untuk keluar dari permainan
    /// </summary>
	public void quit(){
		Application.Quit();
	}
}
