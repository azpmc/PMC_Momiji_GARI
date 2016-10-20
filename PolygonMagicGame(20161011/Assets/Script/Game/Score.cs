using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Score : MonoBehaviour {

 

    Text text;
    GameObject StageGenerater;      
    public static int m_Score;

	// Use this for initialization
	void Start () {

        StageGenerater = GameObject.Find("StageManager");
        text = GetComponent<Text>();
        m_Score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        float dis =StageGenerater.GetComponent<StageManager>().GetDistance();
        m_Score = (int)dis;

        text.text = "Score:" + m_Score.ToString("000000");
	}


    public int GetScoreValue()
    {
        return m_Score;
    }
}
