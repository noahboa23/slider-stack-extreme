using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public bool reset = false;
    void Start()
    {

    }

    void Update()
    {
        if (reset)
        {
            reset = false;
            Transform parentTransform = transform;
            foreach (Transform child in parentTransform)
            {
                //Take the toppings on the bun and destroy them.
                Destroy(child.gameObject);
            }
            //Set the bun to the top of the slider.
            tag = "top";
        }
    }
}
