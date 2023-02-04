using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehavior : BaseEnemy
{
    private GameObject player;

    // Bullet Variables
    [SerializeField] private GameObject bullet;
    private float directionToPlayer;
    private Vector2 directionVector;
    [SerializeField] private float shotSpeed;
    [SerializeField] private float shotInterval;
    [SerializeField] private float shotIntervalMin;
    [SerializeField] private float shotIntervalMax;
    [SerializeField] private float bulletAge = 0.5f;
    private float ticks;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shotInterval = Random.Range(shotIntervalMin, shotIntervalMax);
        ticks = 0;
    }



    // Update is called once per frame
    void Update()
    {
        if (ticks > shotInterval)
        {
            ShootBullet();
            ticks = 0;
            shotInterval = Random.Range(shotIntervalMin, shotIntervalMax);
        }
        else
        {
            ticks++;
        }


    }

    private void ShootBullet()
    {
        Vector3 playerPos = player.transform.position;

        // Calculate direction from spider to player
        directionVector = (player.transform.position - transform.position).normalized;

        // Shoot bullet
        GameObject bulletShot = Instantiate(bullet, this.transform.position, Quaternion.identity);
        Rigidbody2D bulletShotRb = bulletShot.GetComponent<Rigidbody2D>();
        bulletShotRb.AddForce(directionVector * shotSpeed);
        Destroy(bulletShot, bulletAge);
    }
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);

        if (health <= 0)
        {
            SpawnDeathParticles();
            this.gameObject.SetActive(false);
        }
    }
}
