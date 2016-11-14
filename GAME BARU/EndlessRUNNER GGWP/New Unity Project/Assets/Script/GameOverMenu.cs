using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
	public void restart(){
		FindObjectOfType<GameGenerator> ().RestartGame ();
	}

	public void backToMainMenu(){		
		SceneManager.LoadScene ("GGWP");
	}

	public void quit(){
		Application.Quit();
	}
}
