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

    // Start is called before the first frame update
    void Start()
    {
        // Set target node  
        targetDestination = bossNodes[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targetDestination.transform.position)
        {
            Debug.Log("Moving");
            transform.position = Vector2.MoveTowards(transform.position, targetDestination.transform.position, speed * Time.deltaTime);
        }
        else if (transform.position == targetDestination.transform.position)
        {
            Debug.Log("Reached");
            int randNode = Random.Range(0, bossNodes.Count);
            Debug.Log("New Node " + randNode);
            targetDestination = bossNodes[randNode];
        }
    }
}
