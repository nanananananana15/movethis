using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToEnemy : MonoBehaviour
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
        if (Random.Range(0, 3) == 0)
        {
            SceneManager.LoadScene("movethis");
        }
        else
        {
            SceneManager.LoadScene("movethis3");
        }
    }
}