using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
    float speed = 0.03f;
    int direction = 1;
    
    public int damage = 0;
    GameObject director;

    GameObject background;

    public GameObject bubblePrefab;
    float bubbleSpan = 1.5f;
    float bubbleTimer = 0;

    void Start()
    {
        director = GameObject.Find("GameDirector");
        background = GameObject.Find("Background");
    }

    void Update()
    {
        if (damage >= 5)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameClearScene");
        }

        if (background.transform.position.y < -20)
        {
            transform.Translate(speed * direction, 0, 0);
        }

        if (transform.position.x <= -2.5f && direction == -1)
        {
            direction = 1; //����������
        }
        else if (transform.position.x >= 2.5f && direction == 1)
        {
            direction = -1; //��������
        }

        //���� �߻�
        bubbleTimer += Time.deltaTime;
        if (bubbleTimer > bubbleSpan)
        {
            bubbleTimer = 0f;
            FireBubble();
        }
    }

    void FireBubble()
    {//�� ������Ʈ �������� ���� ��ġ ������ ����
        if (background.transform.position.y < -20)
        {
            if (bubblePrefab != null)
            {
                Vector3 left = new Vector3(transform.position.x - 0.35f, transform.position.y - 0.9f, transform.position.z);
                Vector3 right = new Vector3(transform.position.x + 0.35f, transform.position.y - 0.9f, transform.position.z);
                GameObject leftBubble = Instantiate(bubblePrefab, left, Quaternion.identity);
                leftBubble.GetComponent<BubbleController>().bubbleSpeed -= speed;
                GameObject rightBubble = Instantiate(bubblePrefab, right, Quaternion.identity);
                rightBubble.GetComponent<BubbleController>().bubbleSpeed -= speed;
                //Instantiate(������ ������Ʈ, ���� ��ġ, ������ ������Ʈ�� ȸ����) Quaternion.identity�� ȸ���� ���� �ʰڴٴ� �ǹ�
            }
        }
    }
}
