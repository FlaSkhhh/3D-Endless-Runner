using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpeed : MonoBehaviour
{
    #region Singleton

    public static ObstacleSpeed instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public float speed;
    public float speedValue;
    public bool roll=false;

    void Start()
    {
        speed = speedValue;
    }
    void FixedUpdate()
    {
        if (!roll)
        {
            if (speedValue >= -40f)
            {
                speedValue += -0.0002830f;
            }
            speed = speedValue;
        }
        else
        {
            speed = 0f;
        }
    }
}
