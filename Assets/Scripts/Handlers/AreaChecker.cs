using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    bool isPlayerInArea = false;
    private void Start()
    {
        
    }
    public bool CheckPlayerInArea() { return isPlayerInArea; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInArea = true;
        }
    }
}
