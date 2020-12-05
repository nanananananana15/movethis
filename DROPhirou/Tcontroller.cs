using UnityEngine;
using System.Collections;

public class Tcontroller : MonoBehaviour
{
    //追跡対象
    public GameObject objTarget;
    //今までいた位置を保持
    public Vector2 prev;
    public Vector2 speed = new Vector2(0.1f, 0.1f);


    public float timer = 2.0f;

    void Start()
    {
        Destroy(gameObject, timer);

        prev = transform.position;

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        //ターゲットの位置と速度の取得
        Vector2 targetPosision = objTarget.transform.position;
        Vector2 targetVelocity = objTarget.GetComponent<Rigidbody2D>().velocity;

        //自分の位置と速度の取得
        Vector2 myPosision = transform.position;
        Vector2 myVelocity = GetComponent<Rigidbody2D>().velocity;

        //ターゲットと自分の速度の差、接近速度
        Vector2 Vr = targetVelocity - myVelocity;
        //ターゲットと自分のベクトル差、接近範囲
        Vector2 Sr = targetPosision - myPosision;

        float tc = 0;
        if (Vr.magnitude != 0)
        {
            //それぞれの絶対値で割ると接近時間が出る
            tc = Sr.magnitude / Vr.magnitude;
        }

        //ターゲットが接近時間後にどこにいるかを算出
        Vector2 St = targetPosision + (targetVelocity * tc);

        //その位置へ自分を指定されたスピードで動かす
        float rad = Mathf.Atan2(St.y - myPosision.y, St.x - myPosision.x);
        myPosision.x += speed.x * Mathf.Cos(rad);
        myPosision.y += speed.y * Mathf.Sin(rad);

        //ロケットの向き修正
        Vector2 diff = myPosision - prev;
        if (diff.magnitude > 0.01)
        {
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        transform.position = myPosision;
        prev = myPosision;
        }
    public void Initialize(GameObject _targetObj)
    {
        objTarget = _targetObj;
    }
}