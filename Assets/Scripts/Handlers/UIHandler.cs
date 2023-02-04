using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text healthVal;
    [SerializeField] private TMP_Text ammoVal;

    [SerializeField] PlayerController controller;
    [SerializeField] PlayerShoot shoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoVal.SetText(shoot.GetCurrentAmmo().ToString());
        healthVal.SetText(controller.GetHealth().ToString());
    }
}
