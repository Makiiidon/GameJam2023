using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    InputHandler input;

    // Start is called before the first frame update
    void Start()
    {
        input = InputHandler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(input.GetShoot())
        {
            Debug.Log("Shooting!");
        }
    }
}
