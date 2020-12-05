using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ESCmap : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

    // Start is called before the first frame update
    void Start()
    {
        //現在値を最大に
        currentHp = maxHp;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentHp <= 0)
        {
            // GameSceneをロード
            SceneManager.LoadScene("WorldMap");
        }
    }
}
