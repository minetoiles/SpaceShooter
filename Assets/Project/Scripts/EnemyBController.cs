using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBController : MonoBehaviour
{//������ ���� �Դٰ��ٰŸ��� �� ����
    int start;
    float speed = 0.01f;
    int direction; //1�̸� ���� -1�̸� �����ʿ��� ����

    public GameObject bubblePrefab;
    float bubbleSpan = 1.5f;
    float bubbleTimer = 0;

    void Start()
    {
        start = Random.Range(0, 2);
        if (start == 0)
        {
            transform.position = new Vector3(-3.5f, 2.5f, 0);
            direction = 1;
        }
        else
        {
            transform.position = new Vector3(3.5f, 2.5f, 0);
            direction = -1;
        }
    }


    void Update()
    {
        transform.Translate(speed * direction, 0, 0);

        if (transform.position.x <= -2.5f && direction == -1)
        {
            direction = 1;
        }
        else if (transform.position.x >= 2.5f && direction == 1)
        {
            direction = -1;
        }

        bubbleTimer += Time.deltaTime;
        if (bubbleTimer > bubbleSpan)
        {
            bubbleTimer = 0f;
            FireBubble();
        }
    }

    void FireBubble()
    {//�� ������Ʈ �������� ���� ��ġ ������ ����
        if (bubblePrefab != null)
        {
            Vector3 bubblePos = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            Instantiate(bubblePrefab, bubblePos, Quaternion.identity);
        }
    }
}
