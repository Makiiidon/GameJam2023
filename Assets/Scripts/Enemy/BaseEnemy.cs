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

    // Damage
    [SerializeField] public int originalDmg;
    [SerializeField] public int fireDmg;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalDmg = 2;
        fireDmg = 4;
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
            TakeDamage(2);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("FireProjectile"))
        {
            TakeDamage(4);
            Destroy(collision.gameObject);
        }
    }
}
