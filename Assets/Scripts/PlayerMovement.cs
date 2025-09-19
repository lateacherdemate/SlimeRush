using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private InputActionReference moveAction;
    private Vector2 moveInput;

    [SerializeField] private InputActionReference jumpAction;
    private bool jumpInput;

    [SerializeField] private InputActionReference sprintAction;
    //private bool sprintInput;

    [SerializeField] private LayerMask groundLayer;

    public float moveSpeed = 7f;
    public float jumpForce = 7f;

    RaycastHit2D hittingFloor;
    public float rayLength = 0.1f;

    private Rigidbody2D rb;
    public bool isGrounded = false;

    //private float originalSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;

        jumpAction.action.performed += HandleJumpInput;

        //sprintAction.action.performed += HandleSprintInput;
    }

    void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }

    void HandleJumpInput(InputAction.CallbackContext context)
    {
        if (isGrounded == true && rb != null)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

   /* void HandleSprintInput(InputAction.CallbackContext context)
    {
        StartCoroutine(SprintReverso());
    }

    private IEnumerator SprintReverso()
    {
        moveSpeed = originalSpeed * 0.5f;
        Debug.Log("Sprint activated");
        yield return new WaitForSeconds(2f);
        moveSpeed = originalSpeed;
        Debug.Log("Sprint ended");
    }
   */
        void Update()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        hittingFloor = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (hittingFloor.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            
        }

    }
}