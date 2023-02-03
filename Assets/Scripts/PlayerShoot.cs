using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    InputHandler input;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shotSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        input = InputHandler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetShoot())
        {
            Debug.Log("Shooting!");
            GameObject bulletShot = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D bulletShotRb = bulletShot.GetComponent<Rigidbody2D>();
            bulletShotRb.AddForce(new Vector2(shotSpeed, 0));

        }
    }

    private void FixedUpdate()
    {
        
    }
}
