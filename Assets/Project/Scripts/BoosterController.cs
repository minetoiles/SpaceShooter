using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{
    GameObject player;
    //∫ŒΩ∫≈Õ »πµÊ
    private void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<PlayerController>().boosterActive = true;
        player.GetComponent<PlayerController>().boosterAudio = true;
        Destroy(gameObject);
    }
     void Start()
    {
        player = GameObject.Find("Player");
    }

}
