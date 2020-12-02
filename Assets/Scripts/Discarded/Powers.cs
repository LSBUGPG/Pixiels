using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{

    public WindPower scriptA;
    public AExplotion scriptB;
    public Shield scriptC;

    public GameObject player;


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.GetComponent<WindPower>().enabled = true;
            player.GetComponent<AExplotion>().enabled = false;
            player.GetComponent<Shield>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.GetComponent<WindPower>().enabled =false;
            player.GetComponent<AExplotion>().enabled = true;
            player.GetComponent<Shield>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.GetComponent<WindPower>().enabled = false;
            player.GetComponent<AExplotion>().enabled = false;
            player.GetComponent<Shield>().enabled = true;
        }
    }
}
