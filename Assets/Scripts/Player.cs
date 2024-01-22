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
        if (Input.GetKey(KeyCode.W))
        {

        }
    }
}
