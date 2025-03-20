using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Vector3 movement;
    private int jumpCnt = 0;

    private Rigidbody rigid;
    
    private void Awake()
    {

    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < 1)
        {
            Jump();
            jumpCnt++;
        }
        Physics.gravity = new Vector3(0, -50f, 0);
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        movement = transform.forward * v + transform.right * h;
        transform.position += movement * speed * Time.deltaTime;
    }

    void Jump()
    {
        rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCnt = 0;
        }
    }
}
