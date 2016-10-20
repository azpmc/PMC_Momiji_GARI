using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameSystem : MonoBehaviour {

    GameObject life;
    GameObject fade;
    public GameObject  PauseMenu;

    GameObject Player;
    GameObject Camera;
    GameObject StageGenerater;

    bool fadestart;

	// Use this for initialization
	void Start () {
        life = GameObject.Find("PlayerLife");
        fade = GameObject.Find("Fade");
        
        fadestart = false;
        PauseMenu.SetActive(false);

        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Main Camera");


    }
	
	// Update is called once per frame
	void Update () {
        if (!fadestart)
        {
            if (life.GetComponent<PlayerLife>().GetPlayerDeathFlg())
            {
                fadestart = true;
                fade.GetComponent<Fade>().FadeStart();
            }
        }

        if( Time.timeScale <= 0.0f)
        {
            PauseMenu.SetActive(true);
        }
        if( Time.timeScale >= 1.0f)
        {
            PauseMenu.SetActive(false);
        }
	
	}


    public void PauseMenuContinue()
    {
        GetComponent<Pause>().PauseSet();
    }

    public void PauseMenuRestart()
    {
        GetComponent<SceneChanger>().NextSceneName = "game";
        fade.GetComponent<Fade>().FadeStart();
        GetComponent<Pause>().PauseSet();

    }

    public void PauseMenuExit()
    {
        GetComponent<SceneChanger>().NextSceneName = "title";
        fade.GetComponent<Fade>().FadeStart();
        GetComponent<Pause>().PauseSet();
    }
}
