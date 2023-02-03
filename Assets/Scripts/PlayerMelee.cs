using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    InputHandler inputHandler;

    [SerializeField] private Vector3 attackPoint;
    [SerializeField] private float attackRadius = 2.5f;
    [SerializeField] private LayerMask whatIsEnemy;

    //Face direction

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = InputHandler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputHandler.GetAttack())
        {
            if (Physics2D.OverlapCircle(attackPoint + transform.position, attackRadius, whatIsEnemy))
            {
                Debug.Log("Atack");

            }
        }
    }
}
