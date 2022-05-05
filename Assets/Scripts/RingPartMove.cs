using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPartMove : MonoBehaviour
{
    private Vector3 Direction;
    float Speed = -0.05f;
    void Start()
    {
        Direction = new Vector3(0f,Speed,0f);
        Destroy(gameObject,15f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Direction;
    }


    
}
