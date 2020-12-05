using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FixedJoystick joystick;//FixedJoystickを取得
    void Start()
    {

    }

    void Update()
    {
        //水平と垂直方向のデータを取得
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        //xとyの値によってポジションを新たに取得する
        transform.position += new Vector3(x, y, 0);
    }
}