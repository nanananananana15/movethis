using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

    public Slider hpBar;
    public Text hpText;

    //攻撃力
    public int Power = 0;

    //最後に攻撃した対象
    public GameObject lastAttackTarget = null;

    private SpriteRenderer renderer;

    //Start is called before the first frame update

    void Start()
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
}