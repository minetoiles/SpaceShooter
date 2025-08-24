using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{

    public float bubbleSpeed = -0.03f;
    GameObject director;

    //�÷��̾�� �浹������ �÷��̾ �������� ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        director = GameObject.Find("GameDirector");
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.damage++;
            director.GetComponent<GameDirector>().PlayerDemage();
        }

        Destroy(gameObject);

    }

    void Update()
    {//���� ȭ�� ������ ������ �ı�
        transform.Translate(0, bubbleSpeed, 0);
        if (transform.position.y < -5.5)
        {
            Destroy(gameObject);
        }

    }
}
