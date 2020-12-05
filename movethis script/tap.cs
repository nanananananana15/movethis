using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class testpunch : MonoBehaviour
{

    public GameObject cat;
    public bool punch;

    // Use this for initialization
    void Start()
    {
        //isAttackableをtrueにしておく
        punch = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    //=====フリック入力を有効・無効にする部分=====
    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
    //=====ここまで=====
}