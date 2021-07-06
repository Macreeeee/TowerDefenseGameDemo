using System.ComponentModel;
using System.Net;
using System.Numerics;
using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.2f;

    private Coroutine coroutine;

    void Start() 
    {
        coroutine = StartCoroutine(SpawnEnemy());   
    }

    public void stop(){
        StopCoroutine(coroutine);   
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, START.position, UnityEngine.Quaternion.identity);
                CountEnemyAlive++;
                if(i != wave.count - 1)
                yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);   
        }

        while (CountEnemyAlive > 0) {
            yield return 0;
        }

        GameManager.instance.Win();
    }
}
