using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Animator animator;
    GameObject Player;
    CharacterController Controller;
    GameObject Life;

    public float MinSpeed;//最少スピード
    public float DefaultPlayerSpeed;//通常スピード
    public float MaxSpeed;//最大
    public float FlashingInterval;//スタン時の点滅処理の間隔を設定
    public float JumpPower;//ジャンプ力
    public float Gravity;//重力
    public float StunTime;//スタン時間

    bool bStart = false;//開始フラグ
    bool bPlayerStun;//プレイヤーのスタン（気絶）フラグ
    float PlayerSpeed;//プレイヤーのスピード
    float time;//スタン状態経過時間
    float FlashingNextTime;//点滅に使用、次の点滅までの時間
    Vector3 MoveP;//移動量

    Vector3 TargetPos;
    Vector3 StartPos;
    float StartTime;
    bool SpeedChange;

    //レンダラーの情報を入れるための配列
    MeshRenderer[] PlayerMesh;
    SkinnedMeshRenderer[] PlayerSkinMesh;


    enum PLAYER_SPEED
    {
        PLAYER_SPEED_DEF =0,
        PLAYER_SPEED_MIN,
        PLAYER_SPEED_MAX,
    };
    PLAYER_SPEED PlayerSpeedStatus;


    // Use this for initialization
    void Start () {

        //各種オブジェクトの取得
        animator = GetComponent<Animator>();
        Player = GetComponent<GameObject>();
        Controller = GetComponent<CharacterController>();
        Life = GameObject.Find("PlayerLife");

        //プレイヤー点滅処理で使用　プレイヤーのメッシュをすべて取得する処理
        PlayerSkinMesh = this.GetComponentsInChildren<SkinnedMeshRenderer>();
        PlayerMesh = this.transform.FindChild("Character1_Reference").GetComponentsInChildren<MeshRenderer>();




        //プレイヤーの移動速度を代入
        PlayerSpeed = DefaultPlayerSpeed;
        //気絶フラグをFalse
        bPlayerStun = false;
        //スタンの経過時間を初期化
        time = 0.0f;


	}
	
	// Update is called once per frame
	void Update () {

  

        //ライフが０以上の場合のみ処理する。
        if (Life.GetComponent<PlayerLife>().Life != 0)
        {

            //ゲームがスタートしていないときの処理
            if (!bStart)
            {
                //プレイヤーアニメーションを再生
                animator.SetBool("Rest", true);

                AnimatorStateInfo i = animator.GetCurrentAnimatorStateInfo(0);
                //アニメーションが再生終了していたらゲームをスタートさせる。
                if (i.normalizedTime > 0.9f)
                {
                    animator.SetBool("Rest", false);
                    bStart = true;
                }
            }   

            //プレイヤーが走っていたら
            if (bStart)
            {
              
                //スタン状態じゃない場合
                if (!bPlayerStun)
                {
                    //走るアニメ再生
                    animator.SetFloat("Speed", 1.0f);

                    //移動量計算
                    //    MoveP.z = 10 * Time.deltaTime;
                    //   MoveP.z += PlayerSpeed * Time.deltaTime;

                    if (SpeedChange)
                    {
                        float diff = Time.timeSinceLevelLoad - StartTime;
                        if (diff > 1)
                        {
                            //補完完了してる場合は最終座標を代入
                            transform.position = TargetPos;
                            SpeedChange = false;
                        }
                        float rate = diff / 1;

                        transform.position = Vector3.Lerp(StartPos, TargetPos, rate);
                    }

                    MoveP.y -= Gravity * Time.deltaTime;//重力加算



                    Vector3 globalDirection = transform.TransformDirection(MoveP);//移動ベクトルをグローバルなベクトルに変換
                    Controller.Move(globalDirection);// * Time.deltaTime);
                }
                else
                {
                    //スタン状態なら

                    //スタン経過時間を計算
                    time = time + Time.deltaTime;
                    
                    //点滅処理、つぎの表示切替タイミングになったら
                    if (Time.time > FlashingNextTime)
                    {

                        //Playerのレンダラーを描画OFFとONを切り替える処理
                        for( int i = 0; i < PlayerMesh.Length; i++)
                        {
                            PlayerMesh[i].enabled = !PlayerMesh[i].enabled;
                        }
                        for( int i=0;i < PlayerSkinMesh.Length; i++)
                        {
                            PlayerSkinMesh[i].enabled = !PlayerSkinMesh[i].enabled;
                        }


                        //次の切り替えタイミングを再計算
                        FlashingNextTime += FlashingInterval;
                   }


                    //スタン状態時間を超えたとき
                    if ( time >= StunTime )
                    {
                        //スタン状態解除
                        bPlayerStun = false;

                        //プレイヤーを描画する
                        for (int i = 0; i < PlayerMesh.Length; i++)
                        {
                            PlayerMesh[i].enabled = true;
                        }
                        for (int i = 0; i < PlayerSkinMesh.Length; i++)
                        {
                            PlayerSkinMesh[i].enabled = true;
                        }

                    }//スタン時間を超えたときのif End


                }//スタン状態if end
                if (Controller.isGrounded)
                {
                   
                    if (animator.GetBool("Jump"))
                        animator.SetBool("Jump", false);
                }
            
            }

        }//ライフが０以上の場合のみ処理ここまで
        else
        {
           //ライフがない
           //アニメーションOFF
            animator.SetFloat("Speed", 0.0f);
        }

            MoveP = Vector3.zero;

       Vector3 pos = transform.position;
    }


    //コライダーの接触判定
    void OnControllerColliderHit(ControllerColliderHit hit)
    {        
        //敵オブジェクトの場合
        if(hit.gameObject.tag == "EnemyObject")
        {
            //スタン経過時間初期化
            time = 0.0f;
            //点滅の次の時間を設定
            FlashingNextTime = Time.time;
            //歩くアニメーション停止
            animator.SetFloat("Speed", 0.0f);
            //スタンフラグTrue
            bPlayerStun = true;

            //ライフダウン
            Life.GetComponent<PlayerLife>().PlayerLifeDown();
            //Hitしたオブジェクトの削除
            Destroy(hit.gameObject);
        }

    }






    public void SpeedUp()
    {
        if (PlayerSpeedStatus == PLAYER_SPEED.PLAYER_SPEED_DEF)
        {
            TargetPos = new Vector3(5, transform.position.y, transform.position.z);
            StartPos = transform.position;
            StartTime = Time.time;
            SpeedChange = true;
            PlayerSpeedStatus = PLAYER_SPEED.PLAYER_SPEED_MAX;
        }
        else if ( PlayerSpeedStatus == PLAYER_SPEED.PLAYER_SPEED_MIN)
        {
            TargetPos = new Vector3(0, transform.position.y, transform.position.z);
            StartPos = transform.position;
            StartTime = Time.time;
            SpeedChange = true;
            PlayerSpeedStatus = PLAYER_SPEED.PLAYER_SPEED_DEF;
        }
    }

    public void SpeedDown()
    {
        if (PlayerSpeedStatus == PLAYER_SPEED.PLAYER_SPEED_MAX)
        {
            TargetPos = new Vector3(0, transform.position.y, transform.position.z);
            StartPos = transform.position;
            StartTime = Time.time;
            SpeedChange = true;
            PlayerSpeedStatus = PLAYER_SPEED.PLAYER_SPEED_DEF;
        }
        else if ( PlayerSpeedStatus == PLAYER_SPEED.PLAYER_SPEED_DEF)
        {
            TargetPos = new Vector3(-5, transform.position.y, transform.position.z);
            StartPos = transform.position;
            StartTime = Time.time;
            SpeedChange = true;
            PlayerSpeedStatus = PLAYER_SPEED.PLAYER_SPEED_MIN;
        }
    }

    public void Jump()
    {
        if (Controller.isGrounded)
        {
            MoveP.y += JumpPower;
            animator.SetBool("Jump", true);
    
        }
    }

    public bool GetStartFlg()
    {
        return bStart;
    }

    public float GetPlayerSpeed()
    {
        if (bStart)
        {
            return PlayerSpeed;
        }
        else
        {
            return 0;
        }
    }
}
