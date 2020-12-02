using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public GameObject Melody;

    public bool shrink;

    void Start()
    {
        shrink = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Shrink"))
        {
            shrink = !shrink;

            if (shrink == true)
            {
                Melody.GetComponent<Animator>().Play("Shrink");
            }
            else
            {
                Melody.GetComponent<Animator>().Play("Back");
            }
        }

    }
}
