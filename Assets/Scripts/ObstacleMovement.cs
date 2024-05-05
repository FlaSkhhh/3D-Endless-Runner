using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        speed = ObstacleSpeed.instance.speed;
    }

    void FixedUpdate()
    {
        speed = ObstacleSpeed.instance.speed;
        rb.velocity = new Vector3(0f, rb.velocity.y, speed);
    }
}
