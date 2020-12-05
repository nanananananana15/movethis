using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

    public Slider hpBar;
    public Text hpText;

    private SpriteRenderer renderer;

    //Start is called before the first frame update

    private void Start()
    {
    
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

    }

    //ダメージ
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//衝突した相手のタグがEnemyなら
        {
            currentHp -= 10;//hpを-1ずつ変える
        }
        if (collision.gameObject.tag == "Arrow")//衝突した相手のタグがEnemyなら
        {
            currentHp -= 5;//hpを-1ずつ変える
        }



    }
    
}