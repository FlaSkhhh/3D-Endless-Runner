using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col!=null)
        {
            if (col.tag=="Obstacle")
            {
                GameObject GO = col.transform.parent.transform.parent.gameObject;
                Destroy(GO);
            }
            if (col.tag == "Building")
            {
                GameObject GO = col.gameObject;
                Destroy(GO);
            }
            if (col.tag == "RoadSide")
            {
                GameObject GO = col.gameObject;
                Destroy(GO);
            }
        }
    }
}
