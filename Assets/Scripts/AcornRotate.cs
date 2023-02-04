using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornRotate : MonoBehaviour
{

    [SerializeField] private float rotate = 5;
    private float ticks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, transform.rotation.z + rotate, Space.Self);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Debug.Log("Touched");
        }   
    }
}
