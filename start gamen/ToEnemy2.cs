using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToEnemy2 : MonoBehaviour
{

    // 始まった時に実行する関数
    void Start()
    {
        // ボタンが押された時、StartGame関数を実行
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // StartGame関数	
    void StartGame()
    {
        // GameSceneをロード
        if (Random.Range(0, 3) == 0)
        {
            SceneManager.LoadScene("enemy2");
        }
        else
        {
            SceneManager.LoadScene("enemy2-2");
        }
    }
}