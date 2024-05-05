using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public GameObject roadLine;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (true)
        {
            GameObject GO;
            GO = Instantiate(roadLine, new Vector3(0f, 0f, 60f), Quaternion.identity);
            yield return new WaitForSeconds(4);
        }
    }
}
