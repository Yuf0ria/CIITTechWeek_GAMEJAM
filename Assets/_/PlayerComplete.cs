/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;
using CodeMonkey;

/*
 * Player movement with WASD
 * */
public class PlayerComplete : MonoBehaviour {

    private const float SPEED = 50f;

    private Player_Base playerBase;
    private Rigidbody2D playerRigidbody2D;
    private Vector3 moveDir;
    private HealthSystem healthSystem;
    private World_Bar healthBar;

    private void Awake() {
        playerBase = gameObject.GetComponent<Player_Base>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        healthSystem = new HealthSystem(200);
        healthBar = new World_Bar(transform, new Vector3(0, 10), new Vector3(10, 1), Color.grey, Color.red, 1f, 10000, new World_Bar.Outline { color = Color.black, size = .6f });

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e) {
        healthBar.SetSize(healthSystem.GetHealthNormalized());
    }

    private void Update() {
        HandleMovementInput();
    }

    private void HandleMovementInput() {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;
        playerBase.PlayMoveAnim(moveDir);
    }

    private void FixedUpdate() {
        playerRigidbody2D.velocity = moveDir * SPEED;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        /*if (collision.gameObject.GetComponent<Rock>() != null) {
            // Player Hit Rock
            healthSystem.Damage(1);

            Vector3 spwanBloodPosition = transform.position + new Vector3(0, -2f);
            Vector3 bloodDir = (spwanBloodPosition - collision.gameObject.transform.position).normalized;
            Blood_Handler.SpawnBlood(1, spwanBloodPosition, bloodDir);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        /*if (collider.GetComponent<HealthPotion>() != null) {
            // Player grabbed Health Potion
            healthSystem.Heal(999);
            Destroy(collider.gameObject);
        }*/
    }

}
