using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    //変数宣言で以下の文を描く
    [SerializeField] Transform targetTrs;
    public GameObject firePrefab;
    float span = 3f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            Transform fireTrs = Instantiate(firePrefab).transform;
            fireTrs.localPosition = targetTrs.localPosition;
        }
    }
}
