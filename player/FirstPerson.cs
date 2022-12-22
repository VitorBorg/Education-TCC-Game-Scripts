using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    private CharacterController controller;

    public float speed;

    bool onGround = false;
    public float radius = 1;
    public LayerMask layer;
    Vector3 gravity;
    public float jump = 4;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        movement();
        gravityAndJump();
    }

    void movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveVector = transform.right * x + transform.forward * z;

        controller.Move(moveVector * speed * Time.deltaTime);
    }

    void gravityAndJump()
    {
        onGround = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z), radius, layer);
    
        if(onGround)
        {
            gravity.y = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravity.y = jump;
                print("Salve");
            }
        } else
        {
            gravity.y += 45;
        }

        controller.Move(gravity * Time.deltaTime);
    }
}
