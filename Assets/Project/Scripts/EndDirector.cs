using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDirector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    { 
        float score = GameDirector.score;
        scoreText.text = "score: " + score.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameDirector.score = 0;
            SceneManager.LoadScene("GameScene");
        }
    }
}
