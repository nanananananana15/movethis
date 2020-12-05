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

    //�U����
    public int Power = 0;

    //�Ō�ɍU�������Ώ�
    public GameObject lastAttackTarget = null;

    private SpriteRenderer renderer;

    //Start is called before the first frame update

    void Start()
    {

        //���ݒl���ő��
        currentHp = maxHp;

        //�X���C�_�[�̍ő�l��ύX
        hpBar.maxValue = maxHp;
    }
    void Update()
    {
        //�X���C�_�[�̒l�����A���^�C���ŕύX
        hpBar.value = currentHp;

        //HP�e�L�X�g��ύX
        //���ݒl/�ő�l�̕\��
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString(); //ToString = ������



    }
}