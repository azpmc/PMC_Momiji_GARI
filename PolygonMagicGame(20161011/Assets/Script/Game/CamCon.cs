using UnityEngine;
using System.Collections;

public class CamCon : MonoBehaviour {

    public GameObject CameraTarget;
    public float CameraFollowSpeed;

    Vector3 dis = Vector3.zero;
	// Use this for initialization
	void Start () {
        
        dis = transform.position - CameraTarget.transform.position;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 test;
        test = new Vector3(CameraTarget.transform.position.x, CameraTarget.transform.position.y, CameraTarget.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, test + dis, Time.deltaTime * CameraFollowSpeed);
	
	}
}
