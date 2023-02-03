using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = InputHandler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(
            input.GetMove().x * speed * Time.deltaTime, 
            rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckOffset + transform.position, groundCheckRadius, groundLayer);

        if (jumpRequest)
        {
            //rb.velocity += Vector2.up * jumpStrength * Time.deltaTime;
            rb.AddForce(Vector2.up * jumpStrength * Time.deltaTime, ForceMode2D.Impulse);
            jumpRequest = false;
        }

        if (!isFacingLeft && input.GetMove().x < 0) // flip to the right 
        {
            Flip();
        }
        else if (isFacingLeft && input.GetMove().x > 0) // flip to the left 
        {
            Flip();
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
    private void Update()
    {

        if (input.GetJump() && isGrounded)
        {
            Debug.Log("Jump");
            jumpRequest = true;
        }
    }


    public void SetJumpRequest(bool value) { jumpRequest = value; }
    public bool IsGrounded() { return isGrounded; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckOffset + transform.position, groundCheckRadius);
    }
}
