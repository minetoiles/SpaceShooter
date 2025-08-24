using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCController : MonoBehaviour
{ //������ �Ʒ��� �������� �� ����
    float x;
    float speed = -0.02f;

    public GameObject bubblePrefab;
    float bubbleSpan = 1.5f;
    float bubbleTimer = 0;

    void Start()
    {
        x = Random.Range(-2, 3);
        transform.position = new Vector3(x, 6.0f, 0);
    }


    void Update()
    {
        transform.Translate(0, speed, 0);

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
            GameObject bubble = Instantiate(bubblePrefab, bubblePos, Quaternion.identity);
            bubble.GetComponent<BubbleController>().bubbleSpeed += speed;
        }
    }
}
