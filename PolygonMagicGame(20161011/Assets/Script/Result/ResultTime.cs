using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour {

    int min;
    float sec;
    Text text;


	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        min = Timer.min;
        sec = Timer.second;

	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Time:" + min.ToString("00") + ":" + sec.ToString("00");

    }
}
