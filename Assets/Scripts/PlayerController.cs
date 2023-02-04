using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    InputHandler input;

    [SerializeField] private float speed = 250f;
    [SerializeField] private float jumpStrength = 250f;

    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private float groundCheckRadius = 3.5f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private SpriteRenderer playerSprite;

    bool jumpRequest = false;

    bool isGrounded;

    bool isFacingLeft = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = InputHandler.Instance;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(
            input.GetMove().x * speed * Time.deltaTime, 
            rb.velocity.y);


        if (jumpRequest)
        {
            //rb.velocity += Vector2.up * jumpStrength * Time.deltaTime;
            rb.AddForce(Vector2.up * jumpStrength * Time.deltaTime, ForceMode2D.Impulse);
            jumpRequest = false;
        }

        
    }

    
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckOffset + transform.position, groundCheckRadius, groundLayer);

        if (!isFacingLeft && input.GetMove().x < 0) // flip to the right 
        {
            Flip();
        }
        else if (isFacingLeft && input.GetMove().x > 0) // flip to the left 
        {
            Flip();
        }

        if (input.GetMove().x != 0 && isGrounded)
        {
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsFalling", false);

        }
        else if (input.GetMove().x == 0 && isGrounded)
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsFalling", false);

        }

        if (input.GetJump() && isGrounded)
        {
            anim.SetTrigger("Jump");
            jumpRequest = true;
        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            anim.SetBool("IsFalling", true);
        }
    }


    private void Flip()
    {
        playerSprite.flipX = isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }

    public bool IsFacingLeft()
    {
        return isFacingLeft;
    }

    public void SetJumpRequest(bool value) { jumpRequest = value; }
    public void Jump() { jumpRequest = true; }
    public bool IsGrounded() { return isGrounded; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckOffset + transform.position, groundCheckRadius);
    }
}
