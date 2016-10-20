//ステージの生成


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {


    const int StageTipSize = 80;

    public Transform character;//ターゲットキャラクタの設定
    public GameObject[] stageTips;//ステージチップのプレファブを収納する配列
    public int startTipIndex;//自動生成開始インデックス
    public int preInstantiate;//生成先読み個数
    public List<GameObject> generatedStageList = new List<GameObject>();//生成済みステージチップ保持リスト
    float distance;//スコアとして使用

    GameObject player;
    Quaternion qua;

    void Start()
    {
        qua = stageTips[0].transform.rotation;
        player = GameObject.Find("Player");

        for( int i = 0; i < preInstantiate; i++)
        {
            generatedStageList[i] = Instantiate(stageTips[Random.Range(0, stageTips.Length)]);
            generatedStageList[i].transform.position = new Vector3(transform.position.x + (StageTipSize*i), transform.position.y, transform.position.z);
        }

        distance = 0;
    }

    void Update()
    {
        if (generatedStageList.Count != 0)
        {

            if (!player.GetComponent<PlayerController>().GetStunFlg())
            {
                for (int i = 0; i < generatedStageList.Count; i++)
                {
                    if (generatedStageList[i] != null)
                    {
                        Vector3 pos = generatedStageList[i].transform.position;
                        generatedStageList[i].transform.position = new Vector3(pos.x - (player.GetComponent<PlayerController>().GetPlayerSpeed() * Time.deltaTime), pos.y, pos.z);
                    }

                }
            }

            distance += player.GetComponent<PlayerController>().GetPlayerSpeed() * Time.deltaTime;


            if (generatedStageList[0].transform.position.x < -StageTipSize)
            {
                if (generatedStageList[0] != null)
                {
                    Destroy(generatedStageList[0]);
                    generatedStageList.RemoveAt(0);

                    GameObject stage = Instantiate(stageTips[Random.Range(0, stageTips.Length)]);
                    stage.transform.position = new Vector3(generatedStageList[1].transform.position.x + (StageTipSize), transform.position.y, transform.position.z);

                    generatedStageList.Add(stage);

                    // generatedStageList[i].transform.position = new Vector3(transform.position.x + (StageTipSize * i), transform.position.y, transform.position.z);
                }
            }


        }

       
    }

    public float GetDistance()
    {
        return distance;
    }


    /*
        int currentTipIndex;

        public Transform character;//ターゲットキャラクタの設定
        public GameObject[] stageTips;//ステージチップのプレファブを収納する配列
        public int startTipIndex;//自動生成開始インデックス
        public int preInstantiate;//生成先読み個数
        public List<GameObject> generatedStageList = new List<GameObject>();//生成済みステージチップ保持リスト


        GameObject player;
        Quaternion qua;

        // Use this for initialization
        void Start()
        {
           qua =  stageTips[0].transform.rotation;

            currentTipIndex = startTipIndex - 1;
            UpdateStage(preInstantiate);

            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {

            transform.position = player.transform.position;

            //キャラクターの位置から現在のステージチップのインデックスを計算する
            int charapositionIndex = (int)(transform.position.x / StageTipSize);

            //次のステージチップに入ったらステージの更新処理を行う
            if (charapositionIndex + preInstantiate > currentTipIndex)
            {
                UpdateStage(charapositionIndex + preInstantiate);
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                StageRegenerate();
            }


        }

        //指定Indexまでのステージチップを生成して管理下におく
        void UpdateStage(int toTipIndex)
        {
            if (toTipIndex <= currentTipIndex)
                return;


            //指定のステージチップまで作成
            for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
            {
                GameObject stageObject = GenerateStage(i);

                generatedStageList.Add(stageObject);


            }

            //ステージ保持上限内になるまで古いステージを削除
            while (generatedStageList.Count > preInstantiate + 2)
            {
                DestroyOldestStage();
            }

            currentTipIndex = toTipIndex;

        }


        //指定のインデックス位置にStageオブジェクトをランダムに生成
        GameObject GenerateStage(int tipIndex)
        {
            int nextStageTip = Random.Range(0, stageTips.Length);

            GameObject stageObject = (GameObject)Instantiate(stageTips[nextStageTip], new Vector3(tipIndex * StageTipSize, 0, 0),qua);
            return stageObject;
        }


        //一番古いステージを削除
        void DestroyOldestStage()
        {
            Destroy(generatedStageList[0]);
            generatedStageList.RemoveAt(0);

        }

        void StageRegenerate()
        {

          //  charapositionIndex = (int)(0.0f / StageTipSize);
            currentTipIndex = startTipIndex - 1;
            UpdateStage(preInstantiate);

        }*/


}
