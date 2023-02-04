using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    InputHandler input;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shotSpeed = 10.0f;
    [SerializeField] private float xOffset = 10.0f;
    [SerializeField] private float yOffset = 10.0f;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int addedAmmo = 5;

    // Start is called before the first frame update
    void Start()
    {
        input = InputHandler.Instance;
        currentAmmo = maxAmmo;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Reload"))
        {
            Destroy(collision.gameObject);

            currentAmmo += addedAmmo;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if(currentAmmo > 0)
        {
            if (input.GetShoot())
            {
                Debug.Log("Shooting!");
                Vector3 spawnTransform = transform.position;
                spawnTransform.y += yOffset;
                if (playerController.IsFacingLeft())
                {
                    spawnTransform.x += (xOffset * -1);
                    GameObject bulletShot = Instantiate(bullet, spawnTransform, Quaternion.identity);
                    Rigidbody2D bulletShotRb = bulletShot.GetComponent<Rigidbody2D>();
                    bulletShotRb.AddForce(new Vector2(-1 * shotSpeed, 0));
                }
                else
                {
                    spawnTransform.x += xOffset;
                    GameObject bulletShot = Instantiate(bullet, spawnTransform, Quaternion.identity);
                    Rigidbody2D bulletShotRb = bulletShot.GetComponent<Rigidbody2D>();
                    bulletShotRb.AddForce(new Vector2(shotSpeed, 0));
                }

                currentAmmo--;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
}
