using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y >= -20)
        {
            transform.Translate(0, -0.01f, 0);
        }
        
    }
}
