using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlatform : MonoBehaviour
{
    [SerializeField] private float maxPlatformTime;
    [SerializeField] private float timeOnPlatform;
    [SerializeField] private bool isPlayerOn;

    [SerializeField] private GameObject leafDestroyParticles;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(isPlayerOn)
        {
            timeOnPlatform++;
            if(timeOnPlatform >= maxPlatformTime)
            {
                this.gameObject.SetActive(false);
                GameObject.Instantiate(leafDestroyParticles, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = false;
            timeOnPlatform = 0;
        }
    }
}
