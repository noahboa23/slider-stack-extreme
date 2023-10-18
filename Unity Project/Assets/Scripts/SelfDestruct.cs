using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float lastTime;
    void Start()
    {
        lastTime = Time.fixedTime;
        // Destroy(gameObject, 20);
    }

    void Update()
    {
        //If at least 20 seconds have passed spawn food.
        if ((Time.fixedTime - lastTime) >= 20)
        {
            Destroy(gameObject);
        }
    }
}
