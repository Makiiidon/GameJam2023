using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    InputHandler inputHandler;

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
            Debug.Log("Atack");
        }
    }
}
