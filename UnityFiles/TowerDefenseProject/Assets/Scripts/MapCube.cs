using System.Numerics;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    //[HideInInspector]
    public GameObject turretGo; //save current turret in cube

    public GameObject buildEffect;

    private Renderer renderer;

    private void Start() {
        renderer = GetComponent<Renderer>();
    }

    public void BuildTurret(GameObject turretPrefab){
        turretGo = GameObject.Instantiate(turretPrefab, transform.position, UnityEngine.Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, UnityEngine.Quaternion.identity);
        Destroy(effect, 1);
    }

    private void OnMouseOver() {
        if (turretGo == null){
            renderer.material.color = Color.grey;
        }
    }

    private void OnMouseExit() {
        renderer.material.color = Color.white;
    }
}
