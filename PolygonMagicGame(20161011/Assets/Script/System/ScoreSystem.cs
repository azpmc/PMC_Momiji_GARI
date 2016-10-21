using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

    public const string HIGH_SCORE_KEY = "highscore";
    int score;
    void Start()
    {
        //セーブデータが存在するかチェック
        if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
        {
            //ハイスコアかどうかチェック
            if (LoadHighScore() <= Score.m_Score)
            {
                SaveHighScore();
                score = Score.m_Score;
            }
            else
            {
                score = LoadHighScore();
            }
        }
        else
        {
            SaveHighScore();
            score = Score.m_Score;
        }

    }



    void SaveHighScore()
    {

        PlayerPrefs.SetInt(HIGH_SCORE_KEY, Score.m_Score);
        PlayerPrefs.Save();
    }

   public int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY, -1);
    }


    public int GetHighScoreValue()
    {
        return score;
    }

    public void SaveDataDelete()
    {
        PlayerPrefs.DeleteAll();
    }

}
