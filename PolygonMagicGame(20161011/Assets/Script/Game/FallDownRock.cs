using UnityEngine;
using System.Collections;

public class FallDownRock : MonoBehaviour {

    public float Gravity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(0, 0, -(Gravity * Time.deltaTime)));
	}

 
}
