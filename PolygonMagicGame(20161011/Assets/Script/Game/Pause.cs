using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     void StartPause()
    {
        Time.timeScale = 0.0f ;
    }

     void ReleasePause()
    {
        Time.timeScale = 1.0f;
    }

    public void PauseSet()
    {
        if(Time.timeScale >=1.0f)
        {
            StartPause();
            return;
        }
        if( Time.timeScale <= 0)
        {
            ReleasePause();
            return;
        }
    }

}