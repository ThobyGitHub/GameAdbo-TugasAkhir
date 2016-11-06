using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreCount += 5 * Time.deltaTime;
		if (scoreCount > hiScoreCount) {
			hiScoreCount = scoreCount;
		}
		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		hiScoreText.text = "High Score: " +  Mathf.Round(hiScoreCount);
	}
}
