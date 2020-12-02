using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WindPower2 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Destroy());
    }

    void Update()
    {
        
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy (gameObject);
    }
}
