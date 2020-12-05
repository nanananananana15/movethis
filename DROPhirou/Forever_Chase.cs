using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ƁA�ǂ�������
public class Forever_Chase : MonoBehaviour
{
    public float timer = 2.0f;

    public string targetObjectName;   // �ڕW�I�u�W�F�N�g��
    public float speed = 1; // �X�s�[�h�FInspector�Ŏw��
    GameObject targetObject;

    void Start() // �ŏ��ɁA�ڕW�I�u�W�F�N�g�������Ă���
    {
        targetObject = GameObject.Find(targetObjectName);
        Destroy(gameObject, timer);
    }

    private void FixedUpdate() // �����ƁA�ڕW�I�u�W�F�N�g�̕����𒲂ׂ�
    {
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
        // ���̕����֎w�肵���ʂŐi��
        float vx = dir.x * speed;
        float vy = dir.y * speed;
        this.transform.Translate(vx / 50, vy / 50,0);
    }
}