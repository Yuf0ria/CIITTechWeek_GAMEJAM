using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerBase PlayerCharacterBase;

    private void Awake()
    {
        PlayerCharacterBase = gameObject.GetComponent<PlayerBase>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float speed = 20f;
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


        bool isIdle =  moveX == 0 && moveY == 0;
        if (isIdle)
        {
            PlayerCharacterBase.PlayIdleAnimation(Vector3.zero);
        }
        else
        {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            PlayerCharacterBase.WalkingAnimation(moveDir);
            transform.position += moveDir * speed * Time.deltaTime;
        }

    }


}
