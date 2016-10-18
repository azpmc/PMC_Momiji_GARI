//ステージの生成


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {

    /* const int StageTipSize = 80;
     int currentTipIndex;

     public Transform character;//ターゲットキャラクタの設定
     public GameObject[] stageTips;//ステージチップのプレファブを収納する配列
     public int startTipIndex;//自動生成開始インデックス
     public int preInstantiate;//生成先読み個数
     public List<GameObject> generatedStageList = new List<GameObject>();//生成済みステージチップ保持リスト

     Quaternion qua;

     // Use this for initialization
     void Start()
     {
         qua = stageTips[0].transform.rotation;

         currentTipIndex = startTipIndex - 1;
         UpdateStage(preInstantiate);
     }

     // Update is called once per frame
     void Update()
     {

         //キャラクターの位置から現在のステージチップのインデックスを計算する
         int charapositionIndex = (int)(character.position.x / StageTipSize);

         //次のステージチップに入ったらステージの更新処理を行う
         if (charapositionIndex + preInstantiate > currentTipIndex)
         {
             UpdateStage(charapositionIndex + preInstantiate);
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

         GameObject stageObject = (GameObject)Instantiate(stageTips[nextStageTip], new Vector3(tipIndex*StageTipSize, 0, 0),qua);
         return stageObject;
     }


     //一番古いステージを削除
     void DestroyOldestStage()
     {
         GameObject oldStage = generatedStageList[0];

          generatedStageList.RemoveAt(0);
         Destroy(oldStage);
     }

     */

    const int StageTipSize = 80;
    int currentTipIndex;

    public Transform character;//ターゲットキャラクタの設定
    public GameObject[] stageTips;//ステージチップのプレファブを収納する配列
    public int startTipIndex;//自動生成開始インデックス
    public int preInstantiate;//生成先読み個数
    public List<GameObject> generatedStageList = new List<GameObject>();//生成済みステージチップ保持リスト

    Quaternion qua;

    // Use this for initialization
    void Start()
    {
       qua =  stageTips[0].transform.rotation;

        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {

        //キャラクターの位置から現在のステージチップのインデックスを計算する
        int charapositionIndex = (int)(character.position.x / StageTipSize);

        //次のステージチップに入ったらステージの更新処理を行う
        if (charapositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charapositionIndex + preInstantiate);
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


}
