using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCurvatureLR : MonoBehaviour
{
    public Material[] materials;
    public float curveDelay = 7f;
    private float curveAmount=0.0008f;
    private float deltaCurve=0f;
    private float finalCurve;
    private float counter=0f;

    void Awake()
    {
        finalCurve = curveAmount;
    }

    void Start()
    {
        StartCoroutine(Curve());
    }

    IEnumerator Curve()
    {
        while (true)
        {
            curveAmount = -1f * curveAmount;
            deltaCurve = curveAmount / 60;
            counter = 0f;
            yield return new WaitForSeconds(curveDelay);
        }
    }

    void FixedUpdate()
    {
        if (counter<120)
        {
            finalCurve = finalCurve + deltaCurve;
            foreach (Material material in materials)
            {
                material.SetFloat("CurveAmountSideways", finalCurve);
            }
            counter++;
        }
    }
}
