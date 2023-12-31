using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region
    public static Transform instance;

    private void Awake()
    {
        instance = this.transform;
    }
    #endregion

    [Header("Move Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    [Header("Gravity")]
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isCharacterGrounded = false;
    private Vector3 velocity = Vector3.zero;

    private Animator anim;
    private PlayerStats stats;


    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void Update()
    {
        HandleIsGrounded();
        HandleJumping();
        HandleGravity();


        HandleRunning();
        HandleMovement();
        HandleAnimations();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = moveDirection.normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        if(!stats.IsDead())
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
        }
    }

    private void HandleAnimations()
    {
        if (moveDirection == Vector3.zero)
        {
            anim.SetFloat("speed", 0, 0.2f, Time.deltaTime);
        }
        else if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("speed", 0.5f, 0.2f, Time.deltaTime);
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("speed", 1f, 0.2f, Time.deltaTime);
        }
    }

    private void HandleIsGrounded()
    {
        isCharacterGrounded = Physics.CheckSphere(transform.position, groundDistance);
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCharacterGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void HandleGravity()
    {
        if (isCharacterGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void GetReferences()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<PlayerStats>();
    }

    private void InitVariables()
    {
        moveSpeed = walkSpeed;
    }
}
