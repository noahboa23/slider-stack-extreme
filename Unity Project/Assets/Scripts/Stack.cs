using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public SelfDestruct scriptToDeactivate;
    public Rigidbody rb;
    public IngredientType IngredientName; // added to determine ingredient kind

    public float error = 10F;

    private bool finished = false;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        // If the topping has not already been stacked and the topping is touching the highest topping, then stack it on top of the slider.
        if (finished == false && otherObject.tag == "top")
        {
            //Set the new topping to the top of the slider.
            tag = "top";
            otherObject.tag = "Untagged";
            //Place the topping on top of the slider.
            Vector3 newPosition;
            if (otherObject.name == "BottomBun")
            {
                newPosition = new Vector3(collision.transform.position.x, collision.transform.position.y + 0.2F, collision.transform.position.z);
            }
            else
            {
                newPosition = new Vector3(collision.transform.position.x, collision.transform.position.y + 0.1F, collision.transform.position.z);
            }
            Vector3 newRotation = new Vector3(-90, 0, 0);
            transform.rotation = Quaternion.Euler(newRotation);
            transform.position = newPosition;
            transform.parent = collision.transform;
            //Turn off SelfDestruct
            scriptToDeactivate.enabled = false;
            rb.isKinematic = true;
            finished = true;
            OrderManager om = (OrderManager)FindObjectOfType(typeof(OrderManager));
            om.UpdateCurrentStack(IngredientName);
        }
        // }
        // You can now do something with 'otherObject'.

    }
}
