
using System.Threading;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 35;

    public float speed = 50;

    public GameObject ExplosionEffectPrefab;

    private Transform target;

    public void SetTarget(Transform target){
        this.target = target;
    }

    private void Update() {
        if (target == null){
            Destroy(this.gameObject);
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy"){
            col.GetComponent<Enemy>().TakeDamage(damage);
            GameObject effect = GameObject.Instantiate(ExplosionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect,1);
            Destroy(this.gameObject);
        }
        if (col.tag == "EnemyForShow"){
            GameObject effect = GameObject.Instantiate(ExplosionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect,1);
            Destroy(this.gameObject);
        }
    }
}
