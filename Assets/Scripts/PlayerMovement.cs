using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementState
    {
        Free,
        AnimationLocked,
        Frozen,
        Slowed
    }

    public CharacterController2D controller;
    public Animator animator;

    public MovementState movementState = MovementState.Free;

    public float moveSpeed = 40.0f;

    float horizontalMove = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (movementState == MovementState.Free)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
            animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove) * moveSpeed);
        }
    }

    // FixedUpdate is called once every pre-determined seconds
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
