using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Timer : MonoBehaviour {

    Text text;
   public static int min;
   public static  float second;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        min = 0;
        second = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player").GetComponent<PlayerController>().GetStartFlg())
        {
            second += Time.deltaTime;
            if (second >= 59.0f)
            {
                min++;
                second = 0.0f;
            }
        }
        text.text= "Time:"+ min.ToString("00") + ":" + second.ToString("00");

	}

    public int GetMin()
    {
        return min;
    }

    public float GetSecond()
    {
        return second;
    }

}
