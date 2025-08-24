using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{//������ ���� �밢�� �������� �����̴� ���� ��ũ��Ʈ
    float x = -0.014f;
    float y = -0.008f;
    float a = -40; //�Ѿ� ȸ����
    
    public GameObject bubblePrefab;

    float bubbleSpan = 1.5f;
    float bubbleTimer = 0;
    
    void Start()
    { //���� ȭ�� �ۿ��� �����Ǹ� x, a���� -1�� ���� ���������� ������ �� �ֵ��� ��
        if (transform.position.x < -3)
        {
            x *= -1;
            a *= -1;
        }
    }

    void Update()
    {
        //�̵� ����
        transform.Translate(x, y, 0);
        
        //ȭ�� ������ ����� �ı�
        if ((transform.position.x < -3.5 && x < 0)
            || (transform.position.x > 3.5 && x > 0))
        {
            Destroy(gameObject);
        }

        //���� ����
        bubbleTimer += Time.deltaTime;
        if (bubbleTimer > bubbleSpan)
        {
            bubbleTimer = 0f;
            FireBubble();
        }
        
    }

    void FireBubble()
    {//�� ������Ʈ �������� ���� ��ġ ���� �� ���� ������ ����
        if (bubblePrefab != null)
        {
            Vector3 bubblePos = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            Instantiate(bubblePrefab, bubblePos, Quaternion.Euler(0,0,a));
        }
    }
}
