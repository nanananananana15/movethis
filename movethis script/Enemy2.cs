using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;

    private Animator anim;
    private float timer;

    public void Attack()
    {
        Debug.Log("攻撃");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

        //通常の状態
        if (currentState.IsName("idle"))
        {
            if (timer > interval)
            {
                anim.SetTrigger("attack");
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}