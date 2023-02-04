using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BaseEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public GameObject particle;

    [SerializeField] public int health = 10;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public virtual void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    public virtual void SpawnDeathParticles() { GameObject.Instantiate(particle, transform.position, Quaternion.identity); }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            TakeDamage(5);
        }
    }
}
