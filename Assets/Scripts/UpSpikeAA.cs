using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class UpSpikeAA : MonoBehaviour
{

    public GameObject spikeA;

    UpSpikeSA animationController;

    void Start()
    {
        animationController = spikeA.GetComponent<UpSpikeSA>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            spikeA.GetComponent<UpSpikeSA>().Animat();
        }
    }

}
