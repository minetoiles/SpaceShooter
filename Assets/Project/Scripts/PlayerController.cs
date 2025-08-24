using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int damage = 0;

    public GameObject bulletPrefab;
    float bulletSpan = 0.5f;
    float bulletTimer = 0;

    public bool boosterActive = false;
    float boosterSpan = 10.0f;
    float boosterTimer = 0;

    public AudioClip boosterSound;
    AudioSource audioSource;
    public bool boosterAudio = true;

    void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (damage >= 5)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }

        //����Ű�� ������ ���� ����
        //ȭ�� ������ ������ �ʵ��� x�� ���� ������
        float x = transform.position.x;
        if (Input.GetKey(KeyCode.RightArrow) && x <= 2.5)
        {
            transform.Translate(0.1f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && x >= -2.5)
        {
            transform.Translate(-0.1f, 0, 0);
        }

        //�ν��� �ð� ����
        if (boosterActive)
        {
            if (boosterAudio == true)
            {
                audioSource.PlayOneShot(boosterSound);
                boosterAudio = false;
            }
            boosterTimer += Time.deltaTime;
            if (boosterTimer > boosterSpan)
            {
                boosterTimer = 0;
                boosterActive = false;
            }
        }

        //�Ѿ� �߻�
        bulletTimer += Time.deltaTime;
        if (bulletTimer > bulletSpan)
        {
            bulletTimer = 0;

            if (boosterActive)
            {
               
                Vector3 leftGun = new Vector3(transform.position.x - 0.38f, transform.position.y + 0.4f, 0);
                Vector3 rightGun = new Vector3(transform.position.x + 0.38f,transform.position.y + 0.4f, 0);

                Instantiate(bulletPrefab, leftGun, Quaternion.identity);
                Instantiate(bulletPrefab, rightGun, Quaternion.identity);
            }
            else
            {
                Vector3 centerGun = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
                Instantiate(bulletPrefab, centerGun, Quaternion.identity);
            }
           
        }
    }
}
