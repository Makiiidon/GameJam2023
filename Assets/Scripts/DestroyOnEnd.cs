using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnd : MonoBehaviour
{


    public void DestroyCall()
    {
        Destroy(this.gameObject,1f);
    }
}
