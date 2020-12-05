using System.Collections;
using UnityEngine;

public class AttackAreaActivatorB : MonoBehaviour
{
    Collider[] attackAreaColliders;//攻撃判定コライダの配列


    // Start is called before the first frame update
    void Start()
    {
        //子供のgameobjectからAttackareaスクリプトがついているgameojectを探す
        AttackAreaB[] attackAreas = GetComponentsInChildren<AttackAreaB>();
        attackAreaColliders = new Collider[attackAreas.Length];

        for (int attackAreaBCnt = 0; attackAreaBCnt < attackAreas.Length; attackAreaBCnt++)
        {
            //AttackAreaスクリプトがついているGameObjectのコライダを配列に格納する。
            attackAreaColliders[attackAreaBCnt] = GetComponent<Collider>() ;
            attackAreaColliders[attackAreaBCnt].enabled = false;
            //初期はfalseにしておく
        }
    }

    //アニメーションイベントのStartAttackHitを受け取ってコライダを有効にする。
    void StartAttackHit()
    {
        foreach (Collider attackAreaBCollider in attackAreaColliders)
            GetComponent<Collider>().enabled = false;
    }
}