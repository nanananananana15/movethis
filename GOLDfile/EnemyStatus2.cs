using UnityEngine;
using System.Collections;

public class EnemyStatus2 : MonoBehaviour
{


	//　敵のHP
	[SerializeField]
	private int hp = 3;
	//　敵の攻撃力
	[SerializeField]
	private int attackPower = 1;

	public void SetHp(int hp)
	{
		this.hp = hp;
	}

	public int GetHp()
	{
		return hp;
	}

}