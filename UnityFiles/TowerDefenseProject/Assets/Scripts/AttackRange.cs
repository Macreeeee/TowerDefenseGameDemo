using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour { 
    public Material material;
    void Update()
    {
        ToDrawCircle(transform,transform.localPosition, 3);      
    }

    private static LineRenderer GetLineRenderer(Transform t)
    {
        LineRenderer lr = t.GetComponent<LineRenderer>();
        if (lr == null)
        {
            lr = t.gameObject.AddComponent<LineRenderer>();
        }

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        return lr;
    }
 
   
    private void ToDrawCircle(Transform t, Vector3 center, float radius)
    {
        LineRenderer lr = GetLineRenderer(t);
        lr.sharedMaterial = material;
        lr.generateLightingData = true;
        int pointAmount = 100;
        float eachAngle = 360f/pointAmount;
        Vector3 forward = t.forward;
        lr.positionCount = (pointAmount + 1);
        for (int i = 0; i <= pointAmount; i++)
        {
            Vector3 pos = Quaternion.Euler(0, eachAngle * i, 0f) * forward * 15 + center;
            pos.y = 1f;
            lr.SetPosition(i, pos);
        }
    }

}