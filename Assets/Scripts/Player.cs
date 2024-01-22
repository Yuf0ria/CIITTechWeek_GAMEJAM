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
        float speed = 40f;
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1) * speed * Time.deltaTime;
        }
    }
}
