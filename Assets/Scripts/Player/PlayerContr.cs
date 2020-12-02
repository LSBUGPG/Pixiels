using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContr : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float movement = 0f;

    public int lives;
    public Text text;

    public bool shield;

    float direction = 1;
    float scale = 0.13263f;
    public float shrinkTime = 1;
    public float normalSize = 0.13263f;
    public float smallSize = 0.03937592f;
    public float yOffset = 1;
    public bool shrink;


    void Start()
    {
        text.GetComponent<Text>().text = "";

        shield = false;

        scale = normalSize;

        shrink = false;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("MoveHorizontal");
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

        transform.localScale = new Vector2(direction*scale, scale);

        if (Input.GetButtonDown ("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }

        else if (Input.GetButtonUp ("Jump"))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * .5f;
        }

        targetVelocity = move * maxSpeed;

        text.text = lives.ToString();

        if (lives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    IEnumerator ShrinkingGrow(bool shrink)
    {
        float from = shrink ? normalSize : smallSize;
        float to = shrink ? smallSize : normalSize;

        for (float time = 0; time < shrinkTime; time += Time.deltaTime)
        {
            scale = Mathf.Lerp(from, to, time / shrinkTime);

            velocity.y += (shrink ? -yOffset : yOffset);

            yield return null;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

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

}