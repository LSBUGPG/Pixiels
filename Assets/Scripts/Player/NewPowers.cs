using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
//using System.Numerics;
using UnityEngine;

public class NewPowers : MonoBehaviour
{

    public GameObject platform;
    public GameObject bomb;
    public GameObject shield;

    private PlatformGM pgm;
    private ShieldGM sgm;

    private PlayerContr player;

    //public GameObject pLight;
    //public GameObject bLight;
    //public GameObject sLight;

    public float cooldownTime = 2;
    public float cooldownTimeShield = 0.5f;
    private float next = 0;

    void Start()
    {
        pgm = GameObject.FindGameObjectWithTag("PGM").GetComponent<PlatformGM>();

        sgm = GameObject.FindGameObjectWithTag("SGM").GetComponent<ShieldGM>();

        player = GetComponent<PlayerContr>();
    }

    void Update()
    {
        if (Time.time > next)
        {
            if (Input.GetButtonDown("Platform"))
            {
              pgm.lastCheckPointPos = transform.position;

                platform.SetActive(true);

                Instantiate(platform, pgm.lastCheckPointPos + new Vector2 (0, -1.8f), transform.rotation);
                StartCoroutine(DeactivatePlatform());

                //pLight.SetActive(true);

                next = Time.time + cooldownTime;
            }
        }

        if (Time.time > next)
        {
            if (Input.GetButtonDown("Explosion"))
            {
                bomb.SetActive(true);

                StartCoroutine(DeactivateBomb());

               //bLight.SetActive(true);

               next = Time.time + cooldownTime;
            }
        }

        if (Time.time > next)
        {
            if (Input.GetButtonDown("Shield"))
            {
                sgm.lastCheckPointPos = transform.position;

                shield.SetActive(true);

                Instantiate(shield, transform);
                StartCoroutine(DeactivateShield());

                player.shield = true;

                //sLight.SetActive(true);

                next = Time.time + cooldownTimeShield;
            }
        }
    }

    IEnumerator DeactivatePlatform()
    {
        yield return new WaitForSeconds(5);

        platform.SetActive(false);
        //pLight.SetActive(false);
    }

    IEnumerator DeactivateBomb()
    {
        yield return new WaitForSeconds(1);

        bomb.SetActive(false);

        yield return new WaitForSeconds(5);

        //bLight.SetActive(false);
    }

    IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(5);

        shield.SetActive(false);

        player.shield = false;

        //sLight.SetActive(false);
    }
}
