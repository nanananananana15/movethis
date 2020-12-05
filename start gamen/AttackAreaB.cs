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

    //�U�������擾����B
    AttackInfo GetAttackInfo()
    {
        AttackInfo attackInfo = new AttackInfo();
        //�U���͂̌v�Z
        attackInfo.attackPower = status.Power;
        attackInfo.attacker = transform.root;

        return attackInfo;
    }

    //���������B
    void OnTriggerEnter(Collider other)
    {
        //�U�����������������damege���b�Z�[�W��������B
        other.SendMessage("Damage", GetAttackInfo());
        //�U�������Ώۂ�ۑ�
        status.lastAttackTarget = other.transform.root.gameObject;
    }

    //�U�������L���ɂ���
    void OnAttack()
    {
        GetComponent<Collider>().enabled = true;
        
    }

    //�U������𖳌��ɂ���
    void OnAttackTermination()
    {
        GetComponent<Collider>().enabled = false;
    }
}
