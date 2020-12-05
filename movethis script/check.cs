using System;
using TouchScript.Gestures;
using UnityEngine;

public class check : MonoBehaviour
{
    private Animator anim = null;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        void PushDownAA()
        {
            anim.SetBool("PunchBool", true);
        }
        void PushUpAA()
        {
            anim.SetBool("PunchBool", false);
        }
    }
}