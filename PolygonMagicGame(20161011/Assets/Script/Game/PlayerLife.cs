﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

    public int Life;
    int MaxLife;
    Text text;

    // Use this for initialization
    void Start()
    {
        //ライフがもし定義されていない場合、とりあえず３にしておく
        if (Life == 0)
        {
           Life = 3;
           
        }
        MaxLife = Life;
        text = this.GetComponent<Text>();



    }
	
	// Update is called once per frame
	void Update () {

        text.text = "Player Life :" + Life.ToString("0");

    }

    public void PlayerLifeDown()
    {
        if( Life >= 1)
        {
            Life--;
        
        }
 
    }

    public void PlayerLifeUP()
    {
        if( Life <  MaxLife)
        {
            Life++;
          
        }
       
    }

    public void PlayerDeath()
    {
        Life = 0;
    }

    public bool GetPlayerDeathFlg()
    {
        if(Life == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
