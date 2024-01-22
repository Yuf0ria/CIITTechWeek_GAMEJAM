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

        Vector3 moveDir = new Vector3(moveX,moveY);
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
