using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Jumping Settings")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        CheckGround();
        HandleJump();
    }

    void MovePlayer()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y, 0f);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f);
        }
    }

    void CheckGround()
    {
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck is not assigned!");
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        Debug.Log(isGrounded ? "Player is on the ground!" : "Player is NOT on the ground!");
    }
}
