using System.Collections;
using UnityEngine;

public class AttackAreaActivatorB : MonoBehaviour
{
    Collider[] attackAreaColliders;//�U������R���C�_�̔z��


    // Start is called before the first frame update
    void Start()
    {
        //�q����gameobject����Attackarea�X�N���v�g�����Ă���gameoject��T��
        AttackAreaB[] attackAreas = GetComponentsInChildren<AttackAreaB>();
        attackAreaColliders = new Collider[attackAreas.Length];

        for (int attackAreaBCnt = 0; attackAreaBCnt < attackAreas.Length; attackAreaBCnt++)
        {
            //AttackArea�X�N���v�g�����Ă���GameObject�̃R���C�_��z��Ɋi�[����B
            attackAreaColliders[attackAreaBCnt] = GetComponent<Collider>() ;
            attackAreaColliders[attackAreaBCnt].enabled = false;
            //������false�ɂ��Ă���
        }
    }

    //�A�j���[�V�����C�x���g��StartAttackHit���󂯎���ăR���C�_��L���ɂ���B
    void StartAttackHit()
    {
        foreach (Collider attackAreaBCollider in attackAreaColliders)
            GetComponent<Collider>().enabled = false;
    }
}