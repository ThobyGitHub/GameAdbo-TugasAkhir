using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public void PlayGame(){
		SceneManager.LoadScene ("endlessRun5");
			}

	public void QuitGame(){

		Application.Quit ();
	}
}
