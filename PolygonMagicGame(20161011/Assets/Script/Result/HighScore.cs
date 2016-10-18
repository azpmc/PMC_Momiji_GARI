using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HighScore : MonoBehaviour {

    int score;
    Text text;
    GameObject scoresystem;
	// Use this for initialization
	void Start () {
        scoresystem = GameObject.Find("ScoreSystem");
       
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score = scoresystem.GetComponent<ScoreSystem>().GetHighScoreValue();
        text.text = "HIGH SCORE : " + score.ToString("000000");

    }
}
