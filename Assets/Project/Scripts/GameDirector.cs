using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameDirector : MonoBehaviour
{
    GameObject scoreText;
    GameObject playerHp;
    GameObject player;
    GameObject bossHp;
    GameObject boss;
    GameObject background;
    public static float score = 0;

    public AudioClip playerDamage;
    AudioSource audioSource;

    public void BossDamage()
    {
        bossHp.GetComponent<Image>().fillAmount -= 0.2f;
        score += 200;
    }
    public void ShotEnemy()
    {
        score += 100;
    }
    public void PlayerDemage()
    {
        playerHp.GetComponent<Image>().fillAmount -= 0.2f;
        audioSource.PlayOneShot(playerDamage);
    }
    void Start()
    {
        scoreText = GameObject.Find("Score");
        playerHp = GameObject.Find("hpGauge");
        player = GameObject.Find("Player");
        bossHp = GameObject.Find("BossHp");
        boss = GameObject.Find("Boss");
        background = GameObject.Find("Background");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "score: " + score.ToString();

        if (player == null)
        {
            Destroy(playerHp);
        }
        else
        {
            RectTransform hpRect = playerHp.GetComponent<RectTransform>();
            Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
            hpRect.anchoredPosition = new Vector2(playerScreenPos.x, 50);
        }

        if (background.transform.position.y < -20)
        {
            if (boss == null)
            {
                Destroy(bossHp);
            }
            else
            {
                RectTransform hpRect = bossHp.GetComponent<RectTransform>();
                Vector3 bossScreenPos = Camera.main.WorldToScreenPoint(boss.transform.position);
                hpRect.anchoredPosition = new Vector2(bossScreenPos.x, 160);
            }
        }
    }

}
