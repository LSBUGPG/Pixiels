using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOff : MonoBehaviour
{

    public GameObject shield;

    void Start()
    {
        StartCoroutine(Destroy());
    }

    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
