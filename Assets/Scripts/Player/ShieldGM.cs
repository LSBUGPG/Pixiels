using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGM : MonoBehaviour
{
    private static ShieldGM instance;
    public Vector2 lastCheckPointPos;

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
}
