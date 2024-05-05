using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsideSpawner : MonoBehaviour
{
    public GameObject[] roadSide;
    public LayerMask Mask;
    private bool spawnleft = true;
    private bool spawnright = true;

    void Update()
    {
        spawnleft = !Physics.CheckBox(new Vector3(-5f, 0f, 70f), new Vector3(5f, 5f, 20f), Quaternion.identity, Mask);
        while (spawnleft)
        {
            SpawnLeft();
        }
        spawnright = !Physics.CheckBox(new Vector3(5f, 0f, 70f), new Vector3(5f, 5f, 20f), Quaternion.identity, Mask);
        while (spawnright)
        {
            SpawnRight();
        }
    }

    void SpawnLeft()
    {
        int num = Random.Range(0, roadSide.Length);
        GameObject GO;
        GO = Instantiate(roadSide[num], new Vector3(-5f,0.1f, 70f), Quaternion.Euler(0f, 180, 0f) );
        spawnleft = false;
    }

    void SpawnRight()
    {
        int num = Random.Range(0, roadSide.Length);
        GameObject GO;
        GO = Instantiate(roadSide[num], new Vector3(5f, 0.1f, 70f), Quaternion.Euler(0f,0, 0f));
        spawnright = false;
    }
}
