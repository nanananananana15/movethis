using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(-10f, 0, 0);

        if (transform.position.x < -5.0f)
        {
            Destroy(gameObject);
        }
    }

}
