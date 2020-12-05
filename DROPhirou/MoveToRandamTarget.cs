using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRandamTarget : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Random.Range(-20.0f, 20.0f) * speed, Random.Range(-20.0f, 20.0f) * speed, 0);
        if(transform.position.x <= endPosition)ScrollEnd();   

    }

    void ScrollEnd()
    {
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
    }
}
