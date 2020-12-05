using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        var diff = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(diff, Vector3.up);
        transform.position += diff.normalized * Time.deltaTime;
    }
}