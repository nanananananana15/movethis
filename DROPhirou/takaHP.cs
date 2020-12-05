using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class takaHP : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float dropRate = 0.1f;
    [SerializeField] private Item itemPrefab;
    [SerializeField] private int number = 1;

    private bool _isDropInvoked;

    public int currentHp;
    public int maxHp;

    public Slider hpBar;
    public Text hpText;


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
        if (currentHp <= 0)
        {
            Destroy(this.gameObject);
            DropIfNeeded();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")//衝突した相手のタグがSwordなら
        {
            currentHp -= 1;//hpを-1ずつ変える
        }
    }

    private void DropIfNeeded()
    {
        if (_isDropInvoked) return;

        _isDropInvoked = true;

        if (Random.Range(0, 1f) >= dropRate) return;

        for (var i = 0; i < number; i++)
        {
            var item = Instantiate(itemPrefab, transform.position, Quaternion.identity);


        }
    }
}