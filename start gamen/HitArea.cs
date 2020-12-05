using System.Collections;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    void Damage(AttackAreaB.AttackInfo attackInfo)
    {
        transform.root.SendMessage ("Damage",attackInfo);
    }
}