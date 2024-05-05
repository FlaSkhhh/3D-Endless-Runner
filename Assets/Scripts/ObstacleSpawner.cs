using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; 
    public LayerMask obsMask;
    private Vector3 coord;
    private float delay = 0.1f;
    private float gapInc = 10f;
    private bool spawn = true;
 
    void Start()
    {
        StartCoroutine(Spawning());
    }

    void Update()
    {
        spawn =! Physics.CheckBox(new Vector3(0f, 0f, 70f), new Vector3(10f, 5f, gapInc), Quaternion.identity, obsMask);
        if (spawn) { StartCoroutine(Spawning()); }
        if (gapInc < 20f)
        {
            gapInc =gapInc +0.0016342f;
        }
    }
    
    IEnumerator Spawning()
    {
        while (spawn)
        {
            coord = new Vector3(0f,0f, 70f);
            int num = Random.Range(0, obstacles.Length);
            GameObject GO;
            GO = Instantiate(obstacles[num], coord, obstacles[num].transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
