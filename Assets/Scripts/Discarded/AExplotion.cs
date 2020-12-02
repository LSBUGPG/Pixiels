using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AExplotion : MonoBehaviour
{

    public GameObject explosion;

    public Camera mainCamera;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touch = mainCamera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Instantiate(explosion, touch, Quaternion.identity);
        }
    }
}
