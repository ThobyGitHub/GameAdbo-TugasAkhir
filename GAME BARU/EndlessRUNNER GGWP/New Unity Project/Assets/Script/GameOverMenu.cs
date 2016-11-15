using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
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
