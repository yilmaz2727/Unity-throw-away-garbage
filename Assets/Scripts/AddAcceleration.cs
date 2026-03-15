/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character_controller;
    private Animator animator;
    [SerializeField] float movement_speed = 4f;
    [SerializeField] float run_speed = 7f;
    [SerializeField] float rotation_speed = 750f;
    [SerializeField] float gravity_multiplier = 0.75f;
    [SerializeField] float jump_force = 2f;

    private float downward_velocity;


    void Start()
    {
        character_controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMoving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;
        bool isRunning = isMoving && Input.GetKey(KeyCode.LeftShift);
        bool isGrounded = character_controller.isGrounded;

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);

        float move_amount = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        Vector3 velocity = new Vector3(horizontal, 0f, vertical).normalized;
        velocity = Quaternion.LookRotation(new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z)) * velocity;

        if (character_controller.isGrounded)
        {
            downward_velocity = -2f;
            if (Input.GetButtonDown("Jump"))
            {
                downward_velocity = jump_force;

                if (!isMoving)
                    animator.SetTrigger("Jump_Idle");
                else if (isRunning)
                    animator.SetTrigger("Jump_Run");
                else
                    animator.SetTrigger("Jump_Walk");
            }

        }
        else
        {
            downward_velocity += Physics.gravity.y * gravity_multiplier * Time.deltaTime;
            if (Input.GetButtonUp("Jump") && downward_velocity > 0f)
            {
                downward_velocity *= 0.5f;
            }
        }

        velocity.y = downward_velocity;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? run_speed : movement_speed;

        Vector3 move = new Vector3(velocity.x, 0f, velocity.z) * currentSpeed;
        move.y = downward_velocity;

        character_controller.Move(move * Time.deltaTime);


        if (move_amount > 0)
        {
            var target_rotation = Quaternion.LookRotation(new Vector3(velocity.x, 0f, velocity.z));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, rotation_speed * Time.deltaTime);
        }



    }
}*/
