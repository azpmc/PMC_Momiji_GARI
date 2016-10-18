using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    public GameObject PlayerPrefab;

    Text text;
       
    public static int m_Score;

	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        m_Score = 0;
	}
	
	// Update is called once per frame
	void Update () {

      
        m_Score = (int)PlayerPrefab.transform.position.x;

        text.text = "Score:" + m_Score.ToString("000000");
	}


    public int GetScoreValue()
    {
        return m_Score;
    }
}
