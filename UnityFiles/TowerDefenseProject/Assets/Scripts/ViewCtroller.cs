using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCtroller : MonoBehaviour
{
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float msw = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h, -msw*60, v) * Time.deltaTime * speed ,Space.World);
        
    }
}
