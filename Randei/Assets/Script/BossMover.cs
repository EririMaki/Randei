using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private float timer = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            rb.velocity = rb.velocity * -1;
            timer = 2.0f;
        }
    }

}
