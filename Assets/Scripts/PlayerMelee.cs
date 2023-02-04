using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMelee : MonoBehaviour
{
    InputHandler inputHandler;
    PlayerController controller;

    [SerializeField] int attackDamage = 2;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius = 2.5f;
    [SerializeField] private LayerMask whatIsEnemy;

    [SerializeField] private Transform attackPointDown;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = InputHandler.Instance;
        controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float attackPos = attackPoint.position.x;

        if (controller.IsFacingLeft())
        {
            attackPos = -0.798f + transform.position.x;
        }
        else if (!controller.IsFacingLeft())
        {
            attackPos = 0.798f + transform.position.x;
        }

        attackPoint.position = new Vector3(attackPos, transform.position.y, transform.position.z);


        if (inputHandler.GetAttack())
        {
            if (inputHandler.GetMove().y < 0 && !controller.IsGrounded())
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointDown.position, attackRadius, whatIsEnemy);
                Debug.Log("Atack");
                foreach (Collider2D enemy in enemies)
                {
                    enemy.GetComponent<BaseEnemy>().TakeDamage(attackDamage);
                }


                if (enemies.Length != 0)
                {
                    controller.SetJumpRequest(true);
                }
            }
            else
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsEnemy);
                Debug.Log("Atack");
                foreach (Collider2D enemy in enemies)
                {
                    enemy.GetComponent<BaseEnemy>().TakeDamage(attackDamage);
                }
            }

            anim.SetTrigger("Attack");

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        Gizmos.DrawWireSphere(attackPointDown.position, attackRadius);
    }
}
