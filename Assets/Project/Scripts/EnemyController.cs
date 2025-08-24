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
        //데미지 1회 입으면 불투명하게 바뀌도록
        if (damage == 1)
        {
            Color newColor = sr.color;
            newColor.a = 0.7f;
            sr.color = newColor;
        }
        //데미지 2회 이상 입으면 파괴
        if (damage >= 2)
        {
            Destroy(gameObject);
            director.GetComponent<GameDirector>().ShotEnemy();
        }
    }
}
