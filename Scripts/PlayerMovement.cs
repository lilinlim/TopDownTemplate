using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //default speed
    // serializefield allows editing variable in unity
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    //for moving
    private Vector2 moveInput;
    //for animating
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //to be able to access it
        rb = GetComponent<Rigidbody2D>();
        //get animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //allows the rb to move
        rb.linearVelocity = moveInput * moveSpeed;
    }

    //player movement
    public void Move(InputAction.CallbackContext context){
        animator.SetBool("isWalking", true);


        //transition of walking to idle sprite
        if(context.canceled){
            animator.SetBool("isWalking", false);
            animator.SetFloat("lastInputX", moveInput.x);
            animator.SetFloat("lastInputY", moveInput.y);
        }

        //walking animation
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("inputX", moveInput.x);
        animator.SetFloat("inputY", moveInput.y);
    }
}
