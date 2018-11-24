﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 1.0f;
    public float power = 0.0f;
    private Rigidbody body;
    private bool isFlying = false;

    void Start()
    {
        this.body = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            body.velocity += Vector3.forward * speed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            body.velocity += Vector3.back * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            body.velocity += Vector3.left * speed;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            body.velocity += Vector3.right * speed;
        }

        // 变大
        if (!isFlying)
        {
            if (Input.GetKey(KeyCode.H))
            {
                transform.localScale = new Vector3(transform.localScale.x * 0.99f, transform.localScale.y * 0.99f, transform.localScale.z * 0.99f);
                power++;
            }
            if (Input.GetKeyUp(KeyCode.H) && power > 0)
            {
                isFlying = true;
                body.velocity += new Vector3(0, power, power);
            }
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            this.Reset();
        }

    }

    void Reset()
    {
        isFlying = false;
        power = 0;
        body.velocity = new Vector3(0, 0, 0);
        body.position = new Vector3(0, 0.5f, 0);
        transform.localScale = new Vector3(1, 1, 1);
    }
}
