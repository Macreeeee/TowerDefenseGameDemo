using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IanInMenu : MonoBehaviour
{

    public GameObject Axis; 
    public float _RotationSpeed = 10; 

    public static bool move = false;



    void Update()
    {        
        transform.LookAt(Camera.main.transform);
        this.transform.RotateAround(Axis.transform.position, Vector3.up, _RotationSpeed);

    }

}
