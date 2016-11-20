using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// MainMenu sebagai kelas utama saat permainan dimulai 
/// bisa memilih untuk memulai permainan
/// bisa memilih untuk keluar dari permainan
/// </summary>
public class MainMenu : MonoBehaviour {
	
    /// <summary>
    /// PlayGame dengan tipe void untuk memulai permainan
    /// </summary>
	public void PlayGame(){
		SceneManager.LoadScene ("GGWP");
	}

    /// <summary>
    /// QuitGame dengan tipe void untuk keluar dari permainan
    /// </summary>
	public void QuitGame(){
		Application.Quit ();
	}
}
