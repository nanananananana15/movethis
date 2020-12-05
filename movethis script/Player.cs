using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FloatingJoystick joystick;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //水平と垂直方向のデータを取得
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        //xとyの値によってポジションを新たに取得する
        transform.position += new Vector3(x*8, y*8, 0);
    }
}