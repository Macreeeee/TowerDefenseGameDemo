
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy" || col.tag == "EnemyForShow"){
            enemys.Add(col.gameObject);
        }
    }

    private void OnTriggerExit(Collider col) {
        if (col.tag == "Enemy"){
            enemys.Remove(col.gameObject);
        }
    }

    public float attackRate = 1;
    private float timer = 0;

    public GameObject bulletPrefab;
    public Transform firePosition;

    public Transform gun;
    
    private void Start() {
        timer = attackRate;
    }
    void Update() {
        if (enemys.Count > 0){
            timer += Time.deltaTime;
            if (enemys[0]!= null){
     
                Vector3 targetPosition = enemys[0].transform.position;
                targetPosition.y = gun.position.y;
                gun.LookAt(targetPosition);
            }
            if (timer >= attackRate){
                Attack();
                timer -= attackRate;
            }
        }    

    }

    void Attack(){
        if (enemys[0] == null){
            UpdateEnemys();
        }
        if (enemys.Count > 0){
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
    }

    public void UpdateEnemys(){
        enemys.RemoveAll(i => i == null);
    }
}
