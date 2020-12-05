using UnityEngine;
using System.Collections;

public class MyStatus : MonoBehaviour
{
	private GameObject equip;

	public void SetHp(int hp)
	{
		this.hp = hp;
	}

	public int GetHp()
	{
		return hp;
	}

	public GameObject GetEquip()
	{
		return equip;
	}

	[SerializeField]
	private int hp;

	//　力
	[SerializeField]
	private int power;
	private WeaponStatus weaponStatus;

	public WeaponStatus GetWeaponStatus()
	{
		return weaponStatus;
	}

	public void SetEquip(GameObject weapon)
	{
		equip = weapon;
		weaponStatus = equip.GetComponent<WeaponStatus>();
	}

	//　自身の力と武器の攻撃力を合わせたダメージ力を返す
	public int GetAttackPower()
	{
		return power + weaponStatus.GetAttackPower();
	}



}