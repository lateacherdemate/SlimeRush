using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    private Vector2 moveInput;

    [SerializeField] private InputActionReference jumpAction;

    [SerializeField] private InputActionReference sneakAction;

    [SerializeField] private InputActionReference shootAction;

    [SerializeField] private LayerMask groundLayer;

    public float moveSpeed = 7f;
    public float sneakMultiplier = 0.5f;
    public float jumpForce = 7f;

    RaycastHit2D hittingFloor;
    public float rayLength = 0.1f;

    private Rigidbody2D rb;
    public bool isGrounded = false;

    private bool sneaking = false;

    public int NumberOfbullets = 0;
    public GameObject bullet;

    private PlayerState playerState;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        sneakAction.action.Enable();
        shootAction.action.Enable();

        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;

        jumpAction.action.performed += HandleJumpInput;

        shootAction.action.performed += HandleShootInput;

        sneakAction.action.started += HandleSneakStarted;
        sneakAction.action.canceled += HandleSneakCanceled;
    }

    private void OnDisable()
    {
        moveAction.action.started -= HandleMoveInput;
        moveAction.action.performed -= HandleMoveInput;
        moveAction.action.canceled -= HandleMoveInput;

        jumpAction.action.performed -= HandleJumpInput;

        shootAction.action.performed -= HandleShootInput;

        sneakAction.action.started -= HandleSneakStarted;
        sneakAction.action.canceled -= HandleSneakCanceled;

        moveAction.action.Disable();
        jumpAction.action.Disable();
        sneakAction.action.Disable();
        shootAction.action.Disable();
    }

    void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void HandleJumpInput(InputAction.CallbackContext context)
    {
        if (isGrounded && rb != null)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void HandleShootInput(InputAction.CallbackContext context)
    {
        if (NumberOfbullets > 0 && bullet != null)
        {
            NumberOfbullets--;
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            float direction = transform.localScale.x;
            Bullets bulletScript = newBullet.GetComponent<Bullets>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(direction);
            }
            playerState.Shoot();

        }
    }

    private void HandleSneakStarted(InputAction.CallbackContext context)
    {
        sneaking = true;
    }

    private void HandleSneakCanceled(InputAction.CallbackContext context)
    {
        sneaking = false;
    }

    void Update()
    {
        hittingFloor = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        isGrounded = hittingFloor.collider != null;
    }

    private void FixedUpdate()
    {
        float currentSpeed = moveSpeed;

        if (sneaking)
        {
            currentSpeed *= sneakMultiplier;
        }

        rb.linearVelocity = new Vector2(moveInput.x * currentSpeed, rb.linearVelocity.y);

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
