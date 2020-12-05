using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damage3 : MonoBehaviour
{
    public int hp = 10;//hpを10にする。SliderのMaxValueとValueはここの値に合わせます
    private Slider _slider;//Sliderの値を代入する_sliderを宣言
    public GameObject slider;//体力ゲージに指定するSlider

    // Use this for initialization
    void Start()
    {
        _slider = slider.GetComponent<Slider>();//sliderを取得する
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = hp;//スライダーとHPの紐づけ
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Sword")//衝突した相手のタグがEnemyなら
        {
            hp -= 1;//hpを-1ずつ変える
        }

        if (hp <= 0)//もしhpが0以下なら
        {
            print("GameOver");//GameOverとコンソールに表示する
        }
    }
}