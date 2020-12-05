using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("何かが判定に入りました");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("何かが判定に入り続けています");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("何かが判定をでました");
    }
}