﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public void PlayGame(){
		SceneManager.LoadScene ("GGWP");
			}

	public void QuitGame(){

		Application.Quit ();
	}
}
