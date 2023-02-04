using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspBehavior : BaseEnemy
{
    [SerializeField] float speed = 250.0f;

    [SerializeField] Transform headPosition;
    [SerializeField] float detectionRange = 1.0f;
    [SerializeField] LayerMask whatIsEdge;

    bool isFacingLeft = true;
    [SerializeField] SpriteRenderer sprite;

    bool bumped = false;


    // Update is called once per frame
    void Update()
    {
        if (!isFacingLeft && rb.velocity.x < 0) // flip to the right 
        {
            Flip();
        }
        else if (isFacingLeft && rb.velocity.x > 0) // flip to the left 
        {
            Flip();
        }

    }

   
    void FixedUpdate()
    {
        bumped = Physics2D.OverlapCircle(headPosition.position, detectionRange, whatIsEdge);
        if (isFacingLeft)
        {
            rb.velocity = new Vector3(-speed * Time.deltaTime ,0,0);
        }
        else if (!isFacingLeft)
        {
            rb.velocity = new Vector3(speed * Time.deltaTime ,0,0);
        }
    }

    private void Flip()
    {
        sprite.flipX = isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }
}
