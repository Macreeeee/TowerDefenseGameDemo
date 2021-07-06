using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BuildManager : MonoBehaviour
{
    public TurretData Turret; 

    public TurretData currentTurretSelected;

    public Text moneyText; 

    public Animator moneyAnimator;

    public int initialMoney = 200;

    public static int money = 200;

    private void Start() {
        money = initialMoney;
        moneyText.text = money + "$";
    }

    void changeMoney(int change){
        money += change;
        moneyText.text = money + "$";
    }

    void Update(){
        if (money + "$" != moneyText.text){
            moneyText.text = money + "$";
        }
        if (Input.GetMouseButtonDown(0)){
            
            // check if the mouse clicked a UI system
            if ( EventSystem.current.IsPointerOverGameObject() == false){
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //check if a mapcube being clicked
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider){
                    //get cube
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (currentTurretSelected != null && mapCube.turretGo == null){
                        if (money >= currentTurretSelected.cost){
                            changeMoney(- currentTurretSelected.cost);
                            mapCube.BuildTurret(currentTurretSelected.turretPrefab);
                            moneyAnimator.SetTrigger("flicker");
                        }
                        else{
                            moneyAnimator.SetTrigger("flicker2");
                        }
                    }
                    else if (mapCube.turretGo != null){
                        
                    }

                }
            }
        }
    }

    public void OnTurretSelected(Boolean isOn){
        if (isOn){
            currentTurretSelected = Turret;
        }
        else {
            currentTurretSelected = null;
        }
    }

    public static void AddRewards( int rewards ){
        money += rewards;
    }
}
