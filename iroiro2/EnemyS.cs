using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyS : MonoBehaviour
{

    public int currentHp;
    public int maxHp;

    public Slider hpBar;
    public Text hpText;

    //Start is called before the first frame update

    void Start()
    {
        //最大HPを設定
        maxHp = 20;
        //現在値を最大に
        currentHp = maxHp;

        //スライダーの最大値を変更
        hpBar.maxValue = maxHp;
    }
    void Update()
    {
        //スライダーの値をリアルタイムで変更
        hpBar.value = currentHp;

        //HPテキストを変更
        //現在値/最大値の表示
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = 文字化
    }                                                          //  on damage
                   
    //ダメージ
    public void Damage()
        //currentHpから-10
    {
            currentHp -= 10;
    }                                                          

}