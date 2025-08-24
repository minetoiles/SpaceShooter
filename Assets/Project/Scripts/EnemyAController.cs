using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{//오른쪽 왼쪽 대각선 방향으로 움직이는 동선 스크립트
    float x = -0.014f;
    float y = -0.008f;
    float a = -40; //총알 회전값
    
    public GameObject bubblePrefab;

    float bubbleSpan = 1.5f;
    float bubbleTimer = 0;
    
    void Start()
    { //왼쪽 화면 밖에서 생성되면 x, a값에 -1을 곱해 우하향으로 움직일 수 있도록 함
        if (transform.position.x < -3)
        {
            x *= -1;
            a *= -1;
        }
    }

    void Update()
    {
        //이동 동선
        transform.Translate(x, y, 0);
        
        //화면 밖으로 벗어나면 파괴
        if ((transform.position.x < -3.5 && x < 0)
            || (transform.position.x > 3.5 && x > 0))
        {
            Destroy(gameObject);
        }

        //버블 생성
        bubbleTimer += Time.deltaTime;
        if (bubbleTimer > bubbleSpan)
        {
            bubbleTimer = 0f;
            FireBubble();
        }
        
    }

    void FireBubble()
    {//적 오브젝트 기준으로 버블 위치 설정 및 각도 설정해 생성
        if (bubblePrefab != null)
        {
            Vector3 bubblePos = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            Instantiate(bubblePrefab, bubblePos, Quaternion.Euler(0,0,a));
        }
    }
}
