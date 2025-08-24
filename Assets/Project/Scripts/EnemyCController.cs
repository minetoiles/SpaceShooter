using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCController : MonoBehaviour
{ //위에서 아래로 내려오는 적 동선
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
    {//적 오브젝트 기준으로 버블 위치 설정해 생성
        if (bubblePrefab != null)
        {
            Vector3 bubblePos = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            GameObject bubble = Instantiate(bubblePrefab, bubblePos, Quaternion.identity);
            bubble.GetComponent<BubbleController>().bubbleSpeed += speed;
        }
    }
}
