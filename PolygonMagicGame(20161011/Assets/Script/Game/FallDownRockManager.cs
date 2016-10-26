using UnityEngine;
using System.Collections;

public class FallDownRockManager : MonoBehaviour {



    GameObject Player;
    public float MinTime;
    public float MaxTime;
    public GameObject fallRockPrefab;
    float TargetTime;
    float NowTime;
    bool calc;
    bool destroyrock;
    GameObject CreateObj;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        CreateObj = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.GetComponent<PlayerController>().GetStartFlg())
        {
            //プレイヤーが走り出していたら

            //もしオブジェクトが生成されていた場合
            if (CreateObj == null)
            {

                //予定時間を計算する
                if (!calc)
                {
                    TargetTime = Random.Range(MinTime, MaxTime);
                    NowTime = 0.0f;
                    calc = true;
                }


                //予定時間になったら
                if (TargetTime < NowTime)
                {
                    int lane = Random.Range(0, 3);
                    CreateObj = Instantiate(fallRockPrefab);
                    switch (lane)
                    {
                        case 0:
                            {
                                CreateObj.transform.position = new Vector3(5, 21, Player.transform.position.z);
                                break;
                            }
                        case 1:
                            {
                                CreateObj.transform.position = new Vector3(0, 21, Player.transform.position.z);
                                break;
                            }
                        case 2:
                            {
                                CreateObj.transform.position = new Vector3(-5, 21, Player.transform.position.z);
                                break;

                            }
                    }

                    TargetTime = 0.0f;
                    NowTime = 0.0f;
                    calc = false;
                }

                NowTime += Time.deltaTime;

            }
            else
            {
                //オブジェクトが既に生成されている
                if( CreateObj.gameObject.transform.position.y < -10 )
                {
                    Destroy(CreateObj);
                    CreateObj = null;
                }

            }
        }

    }

}
