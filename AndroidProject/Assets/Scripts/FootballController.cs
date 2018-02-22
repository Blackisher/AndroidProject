﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballController : MonoBehaviour {

    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        started = false;
        gameOver = false;
    }


    // Use this for initialization
    void Start()
    {
        
    }

    void ChangeDirection(){
        if (rb.velocity.x > 0 ) {
            rb.velocity = new Vector3(0, 0, speed);
        } else {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        /*if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }*/

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            ChangeDirection();
        }
    }
}
