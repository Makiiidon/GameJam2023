using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedGravity : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float glideMultiplier = 2.5f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    InputHandler inputHandler;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = InputHandler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0 && Input.GetKey(inputHandler.ReturnJump()))
        {
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            rb.gravityScale = glideMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(inputHandler.ReturnJump()))
        {
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            rb.gravityScale = lowJumpMultiplier;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else
        {
            rb.gravityScale = 1.0f;
        }
    }
}
