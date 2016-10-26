using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hScore : MonoBehaviour {

    int hiscore;
    GameObject score;
	// Use this for initialization
	void Start () {
        hiscore = PlayerPrefs.GetInt(ScoreSystem.HIGH_SCORE_KEY, -1);
        score = GameObject.Find("Score");
    }
	
	// Update is called once per frame
	void Update () {

        if(score.GetComponent<Score>().GetScoreValue() > hiscore)
        {
            GetComponent<Text>().text = "HighScore:" + score.GetComponent<Score>().GetScoreValue();
        }
        else
        {
            GetComponent<Text>().text = "HighScore:" + hiscore;
        }
	
	}
}
