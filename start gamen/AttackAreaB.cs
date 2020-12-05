using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackAreaB : MonoBehaviour 
{ 
    CharacterStatus status;

    void Start()
    {
        status = transform.root.GetComponent<CharacterStatus>();   
    }

    public class AttackInfo
    {
        public int attackPower;
        public Transform attacker;
    }

    //UŒ‚î•ñ‚ğæ“¾‚·‚éB
    AttackInfo GetAttackInfo()
    {
        AttackInfo attackInfo = new AttackInfo();
        //UŒ‚—Í‚ÌŒvZ
        attackInfo.attackPower = status.Power;
        attackInfo.attacker = transform.root;

        return attackInfo;
    }

    //“–‚½‚Á‚½B
    void OnTriggerEnter(Collider other)
    {
        //UŒ‚‚ª“–‚½‚Á‚½‘Šè‚ÌdamegeƒƒbƒZ[ƒW‚ğ‚¨‚­‚éB
        other.SendMessage("Damage", GetAttackInfo());
        //UŒ‚‚µ‚½‘ÎÛ‚ğ•Û‘¶
        status.lastAttackTarget = other.transform.root.gameObject;
    }

    //UŒ‚”»’è‚ğ—LŒø‚É‚·‚é
    void OnAttack()
    {
        GetComponent<Collider>().enabled = true;
        
    }

    //UŒ‚”»’è‚ğ–³Œø‚É‚·‚é
    void OnAttackTermination()
    {
        GetComponent<Collider>().enabled = false;
    }
}
