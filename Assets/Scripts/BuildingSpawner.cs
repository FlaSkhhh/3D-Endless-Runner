using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] buildings;
    public LayerMask buildMask;
    private bool spawnleft = true;
    private bool spawnright = true;
    private float xcoordL;
    private float xcoordR;
    private float zcoord;

    void Update()
    {
        spawnleft = !Physics.CheckBox(new Vector3(-6f, 0f, 90f), new Vector3(10f, 10f, 3f), Quaternion.identity, buildMask);
        while (spawnleft)
        {
            SpawnLeft();
        }
        spawnright = !Physics.CheckBox(new Vector3(6f, 0f, 90f), new Vector3(10f, 10f, 3f), Quaternion.identity, buildMask);
        while (spawnright)
        {
            SpawnRight();
        }
    }

    void SpawnLeft()
    {
        int num = Random.Range(0, buildings.Length);
        GameObject GO;
        xcoordL = 5f + buildings[num].transform.GetChild(0).position.x;
        zcoord = buildings[num].transform.GetChild(0).position.z;
        GO = Instantiate(buildings[num], new Vector3(-xcoordL,0f,90f-zcoord), buildings[num].transform.rotation);
        spawnleft = false;
    }

    void SpawnRight()
    {
        int num = Random.Range(0, buildings.Length);
        GameObject GO;
        xcoordR = 5f + buildings[num].transform.GetChild(0).position.x;
        zcoord = buildings[num].transform.GetChild(0).position.z;
        GO = Instantiate(buildings[num], new Vector3(xcoordR, 0f, 90f - zcoord), Quaternion.Euler(0, -90, 0));
        spawnright = false;
    }
}
