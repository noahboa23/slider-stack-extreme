using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionReset : MonoBehaviour
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
                //Take the first topping and make it not a child to the bun
                child.parent = null;
                //Enter the recursive explode function for the toppings.
                explode(child.gameObject);
            }
            tag = "top";
            StackHeight height = (StackHeight)FindObjectOfType(typeof(StackHeight));
            height.reset();
        }
    }
    void explode(GameObject parent)
    {
        //Set the topping to not kinematic and set the drag to 0.
        Rigidbody rigidbody = parent.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.drag = 0;
        //Move the topping to a random position and orientation and let it fall.
        Vector3 newPosition = new Vector3(parent.transform.position.x + Random.Range(-2, 2), parent.transform.position.y + Random.Range(0, 3), parent.transform.position.z + Random.Range(-2, 2));
        parent.transform.position = newPosition;
        Vector3 newRotation = new Vector3(-90 + Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45)); // Rotate 90 degrees around the Y-axis
        parent.transform.rotation = Quaternion.Euler(newRotation);
        SelfDestruct selfDestruct = parent.GetComponent<SelfDestruct>();
        selfDestruct.lastTime = Time.fixedTime;
        selfDestruct.enabled = true;
        //Recursively call the next topping and make it not a child to the current topping.
        Transform parentTransform = parent.transform;
        foreach (Transform child in parentTransform)
        {
            child.parent = null;
            explode(child.gameObject);
        }
    }
}