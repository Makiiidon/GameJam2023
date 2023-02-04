using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelProgressionHandler : MonoBehaviour
{
    [SerializeField] AreaChecker[] progressionPoints;
    [SerializeField] CinemachineVirtualCamera vcam;
    float dollyPosition = 0f;
    int ctr = 0;
    int levelCount;
    [SerializeField] List<GameObject> levels;

    // Level Prefabs
    [SerializeField] private GameObject level2;

    // Start is called before the first frame update
    void Start()
    {
        levelCount = -1; // To start at 0
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = ctr; i < progressionPoints.Length; i++)
        {
            if (progressionPoints[i].CheckPlayerInArea())
            {
                // Trigger
                dollyPosition += 1;
                ctr++;
                var dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();
                dolly.m_PathPosition = dollyPosition;
                // Spawn Next Level
                levelCount++;
                levels[levelCount].SetActive(true);
            }
        }

    }
}
