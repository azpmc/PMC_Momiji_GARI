using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


//シーンの変更管理スクリプト
public class SceneChanger : MonoBehaviour {

    public string NextSceneName;//遷移先シーンの名前

    public void LoadScene()
    {
        SceneManager.LoadScene(NextSceneName);

    }
}
