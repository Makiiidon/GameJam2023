using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBehavior : MonoBehaviour
{

    [SerializeField] private float rotate = 5;
    private float ticks;
    [SerializeField] private float age;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, transform.rotation.z + rotate, Space.Self);
        ticks++;
        if(ticks >= age)
        {
            gameObject.SetActive(false);
        }
    }
}
