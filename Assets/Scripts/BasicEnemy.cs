using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemy : MonoBehaviour
{

    public float speed;

    public bool move;

    void Start()
    {
        
    }

    void Update()
    {
        if(move)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0,0);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0,0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Turn"))
        {
            if(move)
            {
                move = false;
            }

            else
            {
                move = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TagChange());
        }
    }

    IEnumerator TagChange()
    {
        yield return new WaitForSeconds(1);

        transform.gameObject.tag = "NonEnemy";

        StartCoroutine(TagBack());
    }

    IEnumerator TagBack()
    {
        yield return new WaitForSeconds(3);

        transform.gameObject.tag = "Enemy";
    }

    /*    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("PracticeScene");
            }
        }
    */
}
