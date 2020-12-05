using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public FloatingJoystick joystick;
    public ButtonState ButtonA;

    // 更新時に呼ばれる
    void Update()
    {
        // ボタンの状態表示
        print("ButtonA Pressed: " + ButtonA.IsPressed());
        print("ButtonA Down: " + ButtonA.IsDown());
        print("ButtonA Up: " + ButtonA.IsUp());
    }
}