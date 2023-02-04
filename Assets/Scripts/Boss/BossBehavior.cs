using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> bossNodes;
    [SerializeField] private GameObject targetDestination;
    [SerializeField] private float speed;
    [SerializeField] private int maxHp;
    [SerializeField] private int currentHp;
    [SerializeField] private GameObject projectileSpawn;


    // Slow Fireball
    private float SFB_ticks;
    [SerializeField] private float SLOWFIREBALL_INTERVAL;
    [SerializeField] private GameObject slowFireball;
    [SerializeField] private float slowFireballSpeed;
    [SerializeField] private float slowFireballAge;
    [SerializeField] private float SBF_ShotDelay;
    private bool SBF_Prepping;
   


    // Start is called before the first frame update
    void Start()
    {
        // Set target node  
        targetDestination = bossNodes[0];
        SFB_ticks = 0;
        SBF_Prepping = false;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        if(CheckDead())
        {
            this.gameObject.SetActive(false);
        }

        // Slow Fireball
        SFB_ticks++;
        if(SFB_ticks >= SLOWFIREBALL_INTERVAL && !SBF_Prepping)
        {
            ShootSlow();
            SFB_ticks = 0;
            SLOWFIREBALL_INTERVAL = Random.Range(250, 400);
        }
        else if (SFB_ticks >= SLOWFIREBALL_INTERVAL && SBF_Prepping)
        {
            SFB_ticks = 0;
        }
            


        if (transform.position.x != targetDestination.transform.position.x)
        {
            Debug.Log("Moving");
            transform.position = Vector2.MoveTowards(transform.position, targetDestination.transform.position, speed * Time.deltaTime);
        }
        else if (transform.position.x == targetDestination.transform.position.x)
        {
            Debug.Log("Reached");
            int randNode = Random.Range(0, bossNodes.Count);
            Debug.Log("New Node " + randNode);
            targetDestination = bossNodes[randNode];
        }
    }

    private bool CheckDead()
    {
        if(currentHp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ShootSlow()
    {
        GameObject bulletShot = Instantiate(slowFireball, projectileSpawn.transform.position, Quaternion.identity);
        SBF_Prepping = true;
        StartCoroutine(FireSlow(bulletShot));
    }

    IEnumerator FireSlow(GameObject bulletShot)
    {
        yield return new WaitForSeconds(SBF_ShotDelay);
        Rigidbody2D bulletShotRb = bulletShot.GetComponent<Rigidbody2D>();
        bulletShotRb.AddForce(new Vector2(0, slowFireballSpeed));
        Destroy(bulletShot, slowFireballAge);
        SBF_Prepping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerProjectile"))
        {
            currentHp--;
        }
        
    }

}
