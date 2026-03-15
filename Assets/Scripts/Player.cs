using UnityEngine;
using UnityEngine.InputSystem;

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

    // ✅ NEW INPUT SYSTEM değerleri
    private Vector2 moveInput;      // Move (WASD / joystick)
    private bool runHeld;           // Run (Shift / mobil run butonu)
    private bool jumpPressed;       // Jump (Space / mobil jump butonu)

    void Start()
    {
        character_controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ✅ Move input artık buradan geliyor
        float horizontal = moveInput.x;
        float vertical = moveInput.y;

        bool isMoving = moveInput.sqrMagnitude > 0.01f;
        bool isRunning = isMoving && runHeld;
        bool isGrounded = character_controller.isGrounded;

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);

        Vector3 velocity = new Vector3(horizontal, 0f, vertical).normalized;

        // Kameraya göre hareket (GTA tarzı)
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Quaternion camRotation = Quaternion.LookRotation(camForward);
        velocity = camRotation * velocity;

        if (character_controller.isGrounded)
        {
            downward_velocity = -2f;

            if (jumpPressed)
            {
                jumpPressed = false; // ✅ tek seferlik zıplama
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
        }

        float currentSpeed = runHeld ? run_speed : movement_speed;

        Vector3 move = new Vector3(velocity.x, 0f, velocity.z) * currentSpeed;
        move.y = downward_velocity;

        character_controller.Move(move * Time.deltaTime);

        if (isMoving)
        {
            var target_rotation = Quaternion.LookRotation(new Vector3(velocity.x, 0f, velocity.z));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, rotation_speed * Time.deltaTime);
        }
    }

    // =========================
    // ✅ PlayerInput (Invoke Unity Events) callback’leri
    // =========================

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        // basılı tutuluyorsa true
        runHeld = context.ReadValueAsButton();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Jump action "performed" olduğunda 1 kere tetikle
        if (context.performed)
            jumpPressed = true;
    }
}