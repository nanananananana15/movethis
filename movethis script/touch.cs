using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{

    //PlayerのAnimatorコンポーネント保存用
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        //PlayerのAnimatorコンポーネントを取得する
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //クリックを押すとjab
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Jab", true);
        }

    }

}