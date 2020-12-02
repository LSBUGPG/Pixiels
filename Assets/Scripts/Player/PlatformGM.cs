using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGM : MonoBehaviour
{
    private static PlatformGM instance;
    public Vector2 lastCheckPointPos;

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    void Update()
    {

    }
}
