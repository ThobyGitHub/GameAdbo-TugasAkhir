using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// ScoreManager adalah kelas untuk menangani perhitungan skor yang di dapat selama permainan berlangsung
/// </summary>
public class ScoreManager : MonoBehaviour {
    /// <summary>
    /// atribut untuk mencatat skor saat bermain
    /// </summary>
	[SerializeField]private Text scoreText;

    /// <summary>
    /// atribut untuk mencatat skor tertinggi
    /// </summary>
	[SerializeField]private Text highScoreText;

    /// <summary>
    /// atribut untuk menyimpan skor sementara
    /// </summary>
	private float scoreCount;
    /// <summary>
    /// atribut untuk menyimpan skor tertinggi sementara
    /// </summary>
	private float highScoreCount;

    /// <summary>
    /// berapa skor yang di dapat per detiknya
    /// </summary>
	[SerializeField]private float pointPerSec;

    /// <summary>
    /// atribut untuk mengetahui apakan skor masi bertambah atau tidak
    /// </summary>
	[SerializeField]private bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		scoreCount = 0;
		scoreIncreasing = true;
		if (PlayerPrefs.GetFloat ("HighScore") != null) {
			highScoreCount = PlayerPrefs.GetFloat ("HighScore");
		} else {
			highScoreCount = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreIncreasing) {
			scoreCount += pointPerSec * Time.deltaTime;
		}
		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore",highScoreCount);
		}
		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);


	}
    /// <summary>
    /// setscoreIncreasing dengan tipe void untuk set true atau false atribut scoreIncreasing
    /// </summary>
    /// <param name="scoreIncreasing"></param>
	public void setscoreIncreasing(bool scoreIncreasing){
		this.scoreIncreasing = scoreIncreasing;
	}
}
