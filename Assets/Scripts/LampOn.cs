using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOn : MonoBehaviour
{
    Light bulb;

    void Start()
    {
        bulb = gameObject.transform.GetChild(2).gameObject.GetComponent<Light>();
        bulb.color= new Color(Random.Range(0, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }

    void Update()
    {
        if (gameObject.transform.position.z < 10f)
        {
            bulb.enabled=true;
        }
    }
}
