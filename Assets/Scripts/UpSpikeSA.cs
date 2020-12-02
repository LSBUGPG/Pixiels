using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSpikeSA : MonoBehaviour
{

    public Animation anim;

    void Start()
    {
        anim.gameObject.GetComponent<Animator>().enabled = false;
    }

    public void Animat()
    {
        anim.gameObject.GetComponent<Animator>().enabled = true;
    }
}
