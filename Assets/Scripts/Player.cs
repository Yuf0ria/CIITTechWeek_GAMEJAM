using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{


    private const float MOVE_SPEED = 5f;
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    private Animator animator;
    
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
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

        moveDir = new Vector3(moveX, moveY).normalized;

        bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle)
        {
            rigidbody2D.velocity = Vector3.zero;
        }
        else
        {
            rigidbody2D.velocity = moveDir * MOVE_SPEED;
            animator.SetFloat("Horizontal",moveDir.x);
        }
    }



}
