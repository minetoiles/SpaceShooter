using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    float enemyTimer = 0;
    float enemySpan = 3.0f;

    float time = 0;

    public GameObject background;
    public GameObject enemyPrefab0;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    void Start()
    {
        int num = Random.Range(0, 3);

        if (num == 0)
        {
            Instantiate(enemyPrefab0);
        }
        else if (num == 1)
        {
            Instantiate(enemyPrefab1);
        }
        else
        {
            Instantiate(enemyPrefab2);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (background.transform.position.y > -20)
        {
            enemyTimer += Time.deltaTime;
            if (enemyTimer > enemySpan)
            {
                int num = Random.Range(0, 3);
                enemyTimer = 0;
                //난이도조절
                if (time >= 5)
                {
                    enemySpan = 2.0f;
                }
                if (time >= 15 && time < 25)
                {
                    Instantiate (enemyPrefab3);
                }
                if (time >= 25)
                {
                    enemySpan = 1.5f;
                }
                
                if (num == 0)
                {
                    Instantiate(enemyPrefab0);
                }
                else if (num == 1)
                {
                    Instantiate(enemyPrefab1);
                }
                else
                {
                    Instantiate(enemyPrefab2);
                }
            }

        }
    }
        
}
