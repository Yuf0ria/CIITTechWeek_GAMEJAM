using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float Move_speed = 10f;
    
    private Rigidbody2D rb;
    private Vector3 moveDir;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        
        
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        moveDir = new Vector3 (moveX, moveY, 0f).normalized;
    }


    private void FixedUpdate()
    {
        rb.velocity = moveDir * Move_speed;
    }

}
