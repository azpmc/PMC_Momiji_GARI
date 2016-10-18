using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour {

    int score;
    Text text;
    
	// Use this for initialization
	void Start () {
      score =  Score.m_Score;
        text = GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score:" +score.ToString("000000");
	
	}
}
