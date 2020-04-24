using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 12.0f, jumpHeight = 3.0f, gravityForce = -9.81f;
    public Camera cam;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Animation")]
    public bool isAnimated;
    public Animator animator;

    bool isGrounded;
    [SerializeField] float groundCheckRadius = 0.4f;
    Vector3 currentVelocity;

    void Update()
    {
        if(isLocalPlayer)
        {
            //Bool set to true if sphere collides with ground
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

            //Ground check
            if (isGrounded && currentVelocity.y < 0)
            {
                currentVelocity.y = -2.0f;
            }

            Movement();
            Gravity();

            return;
        }

        cam.gameObject.SetActive(false);
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movePos = transform.right * x + transform.forward * z;

        if(isAnimated)
        {
            animator.SetBool("isWalking", movePos.magnitude > 0.1f ? true : false);

            animator.SetBool("isIdle", movePos.magnitude == 0.0f ? true : false);
        }

        controller.Move(movePos * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            currentVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityForce);
        }
    }

    void Gravity()
    {
        currentVelocity.y += gravityForce * Time.deltaTime;

        controller.Move(currentVelocity * Time.deltaTime);
    }
}
