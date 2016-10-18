using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartText : MonoBehaviour {

    GameObject player;
    Text text;
	// Use this for initialization
	void Start () {
      //  gameObject.SetActive(false);
        player = GameObject.Find("Player");

	}
	
	// Update is called once per frame
	void Update () {
        if( player.GetComponent<PlayerController>().GetStartFlg())
        {
            text = this.GetComponent<Text>();
            text.color = new Color(255, 255, 255, 255);
            Invoke("Disable",5);
        }
	
	}

    void Disable()
    {
        gameObject.SetActive(false);

    }

}
