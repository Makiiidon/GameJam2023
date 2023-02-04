using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootWallBehavior : MonoBehaviour
{
    [SerializeField] List<BaseEnemy> attachedEnemies;
    private int defeatedEnemies;
    private int maxEnemies;

    // Start is called before the first frame update
    void Start()
    {
        defeatedEnemies = 0;
        maxEnemies = attachedEnemies.Count;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Check Dead: " + CheckDead());

        if(CheckDead())
        {
            this.gameObject.SetActive(false);
        }
    }

    private bool CheckDead()
    {
        for(int i = 0; i < attachedEnemies.Count; i++)
        {
            if(!attachedEnemies[i].gameObject.activeInHierarchy)
            {
                defeatedEnemies++;
            }
        }

        if(defeatedEnemies == maxEnemies)
        {
            defeatedEnemies = 0;
            return true;
        }
        else
        {
            defeatedEnemies = 0;
            return false;
        }

       
    }
}
