using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletSpeed = 0.3f;
    GameObject director;
    private void OnTriggerEnter2D(Collider2D other)
    { //���̳� ������ �浹�� ������ ����
        Destroy(gameObject);

        EnemyController enemy = other.GetComponent<EnemyController>();
        BossController boss = other.GetComponent<BossController>();
        if (enemy != null)
        {
            enemy.damage++;
        }
        if (boss != null)
        {
            boss.damage++;
            director.GetComponent<GameDirector>().BossDamage();
        }
    }
    

    void Start()
    {
        director = GameObject.Find("GameDirector");  
    }

    void Update()
    { //�Ѿ� ȭ�� ������ ������ �ı�
        transform.Translate(0, bulletSpeed, 0);
        if (transform.position.y > 5.0)
        {
            Destroy(gameObject);
        }
    }
}
