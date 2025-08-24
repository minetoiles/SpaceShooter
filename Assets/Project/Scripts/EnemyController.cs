using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject director;
    public int damage = 0;
    SpriteRenderer sr;



    void Start()
    {
        director = GameObject.Find("GameDirector");
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //������ 1ȸ ������ �������ϰ� �ٲ��
        if (damage == 1)
        {
            Color newColor = sr.color;
            newColor.a = 0.7f;
            sr.color = newColor;
        }
        //������ 2ȸ �̻� ������ �ı�
        if (damage >= 2)
        {
            Destroy(gameObject);
            director.GetComponent<GameDirector>().ShotEnemy();
        }
    }
}
