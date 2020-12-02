using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExplosion : MonoBehaviour
{
    public GameObject bomb;

    void Start()
    {
        
    }


    void Update()
    {
        Invoke("DelayedDestroy", 0.5f);
    }

    void DelayedDestroy()
    {
        bomb.SetActive(false);
    }
}
