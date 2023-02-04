using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WaspBehavior : BaseEnemy
{
    [SerializeField] float speed = 250.0f;

    [SerializeField] Transform headPosition;
    [SerializeField] float detectionRange = 0.01f;
    [SerializeField] LayerMask whatIsEdge;

    bool isFacingLeft = true;
    
    [SerializeField] SpriteRenderer sprite;

    bool bumped = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
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
        else
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        bumped = Physics2D.OverlapCircle(headPosition.position, detectionRange, whatIsEdge);
        float direction = 1;

        if (isFacingLeft)
        {
            direction = -1;
            if (bumped)
            {
                direction = 1;
            }
        }
        else if (!isFacingLeft)
        {
            direction = 1;
            if (bumped)
            {
                direction = -1;
            }
        }

        rb.velocity = new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }

    private void Flip()
    {
        sprite.flipX = isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }

    public override void TakeDamage(int damageAmount) {
        base.TakeDamage(damageAmount);

        if (health <= 0)
        {
            anim.SetTrigger("Death");
            SpawnDeathParticles();
            alive = false;
        }
    }
}
