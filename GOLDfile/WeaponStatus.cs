using UnityEngine;
using System.Collections;

public class WeaponStatus : MonoBehaviour
{
    public enum WeaponType
    {
        Sword,
        Magic   
    }

    [SerializeField]
    private int attackPower;
    [SerializeField]
    private int apPower;
    [SerializeField]
    private WeaponType weaponType;
    [SerializeField]
    private float weaponRange;

    public int GetAttackPower()
    {
        return attackPower;
    }

    public int GetApPower()
    {
        return apPower;
    }

    public WeaponType GetWeaponType()
    {
        return weaponType;
    }
}
