using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContr : MonoBehaviour
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float movement = 0f;
    public float maxGroundAngle = 50.0f;

    public int lives;
    public Text text;

    public bool shield;

    float direction = 1;
    float scale = 0.13263f;
    public float shrinkTime = 1;
    public float normalSize = 0.13263f;
    public float smallSize = 0.03937592f;
    public bool shrink;
    new Rigidbody2D rigidbody2D;
    List <Collider2D> ground = new List<Collider2D>();


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        text.GetComponent<Text>().text = "";

        shield = false;

        scale = normalSize;

        shrink = false;
    }

    void Update()
    {
        movement = Input.GetAxis("MoveHorizontal");

        if (movement < 0f)
        {
            direction = 1;
        }

        if (movement > 0f)
        {
            direction = -1;
        }

        if (Input.GetButtonDown("Shrink"))
        {
            shrink = !shrink;
            StartCoroutine(ShrinkingGrow(shrink));
        }

        Vector2 velocity = rigidbody2D.velocity;
        if (Input.GetButtonDown ("Jump") && ground.Count > 0)
        {
            velocity += Vector2.up * jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp ("Jump"))
        {
            if (velocity.y > 0)
                velocity.y *= 0.5f;
        }

        velocity.x = movement * maxSpeed;
        rigidbody2D.velocity = velocity;

        text.text = lives.ToString();

        if (lives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.localScale = new Vector2(direction*scale, scale);
    }

    IEnumerator ShrinkingGrow(bool shrink)
    {
        float from = shrink ? normalSize : smallSize;
        float to = shrink ? smallSize : normalSize;
        for (float time = 0; time < shrinkTime; time += Time.deltaTime)
        {
            scale = Mathf.Lerp(from, to, time / shrinkTime);
            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Ground"))
        {
            bool flat = false;
            foreach (ContactPoint2D contact in coll.contacts)
            {
                if (Vector2.Angle(Vector2.up, contact.normal) < maxGroundAngle)
                {
                    flat = true;
                    break;
                }
            }
            if (flat)
            {
                ground.Add(coll.collider);
            }
        }
        if (!shield)
        {
            if (coll.gameObject.tag == "Spikes")
            {
                lives--;
            }

            if (coll.gameObject.tag == "Enemy")
            {
                lives--;
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Ground"))
        {
            ground.Remove(coll.collider);
        }
    }
}
