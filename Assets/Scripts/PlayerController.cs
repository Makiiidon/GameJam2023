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
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int playerHealth = 5;
    [SerializeField] private int addedHealth = 1;

    public bool isBossLevel = false;

    bool jumpRequest = false;

    bool isGrounded;

    bool isFacingLeft = true;

    Animator anim;

    [SerializeField] ParticleSystem leaves1;
    [SerializeField] ParticleSystem leaves2;
    [SerializeField] GameObject deathParticles;

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

        if (isBossLevel)
        {
            rb.velocity = new Vector2(
            input.GetMove().x * speed * Time.deltaTime,
            input.GetMove().y * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(
            input.GetMove().x * speed * Time.deltaTime,
            rb.velocity.y);
        }


        if (jumpRequest && !isBossLevel)
        {
            //rb.velocity += Vector2.up * jumpStrength * Time.deltaTime;
            rb.AddForce(Vector2.up * jumpStrength * Time.deltaTime, ForceMode2D.Impulse);
            jumpRequest = false;
        }



    }

    //Player damage taking
    public virtual void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        if (playerHealth <= 0)
        {
            this.gameObject.SetActive(false);
            GameObject.Instantiate(deathParticles, transform.position, Quaternion.identity);
        }
    }

    //Damage taking
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Debug.Log("Damage taken");
        }
    }

    //Health Pickup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Health pickup
        if (collision.gameObject.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);

            playerHealth += addedHealth;
            Debug.Log("Got Healed");

            //Sets health to max if exceeds the set maximum health
            if (playerHealth > maxHealth)
            {
                playerHealth = maxHealth;
                Debug.Log("Already at Max Health");
            }
        }

        //Enemy projectile hit register
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage(1);
            Debug.Log("Got shot");
            Destroy(collision.gameObject);
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

    public int GetHealth() { return playerHealth; }

    public void PlayParticles() {
        leaves1.Play();
        leaves2.Play();
    }
    
    public void StopParticles() {
        leaves1.Stop();
        leaves2.Stop();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckOffset + transform.position, groundCheckRadius);
    }
}
