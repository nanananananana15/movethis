using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(-3f, 0, 0);

        if(transform.position.x < -5.0f)
        {
            Destroy(gameObject);
        }
    }

}
