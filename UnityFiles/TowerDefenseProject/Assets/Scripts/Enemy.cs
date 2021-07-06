using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public int hp = 100;
    public int rewards = 40;

    public GameObject explosionEffectPrefab;

    private Slider hpSlider;
    private Transform[] positions;

    private int totalHp;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        positions = WayPoint.positions;
        
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
        hpSlider.value = (float)hp/totalHp;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {   
        if (index>positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized*Time.deltaTime *speed );
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index += 1;
        }
        if (index > positions.Length -1)
        {
            ReachDestination();
        }
    }

    void ReachDestination()
    {
        GameManager.instance.Lose();
        GameObject.Destroy(this.gameObject);

    }
    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(int damage){
        if (hp<=0) return;
        hp -= damage;
        hpSlider.value = (float)hp/totalHp;
        if (hp<=0){
            GameObject effect = GameObject.Instantiate(explosionEffectPrefab,transform.position, transform.rotation);
            Destroy(effect,1);
            Destroy(this.gameObject);
            BuildManager.AddRewards(rewards);
        }

    }

}
