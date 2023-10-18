using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public SelfDestruct scriptToDeactivate;
    public Rigidbody rb;

    public float error = 10F;

    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // The 'collision' parameter contains information about the collision, including the other GameObject.
        GameObject otherObject = collision.gameObject;
        // Destroy(this.gameObject);
        // print(transform.position);
        // print(collision.transform.position);
        // if (transform.position.x - error < collision.transform.position.x &&
        //     transform.position.x + error > collision.transform.position.x &&
        //     transform.position.y - error < collision.transform.position.y &&
        //     transform.position.y + error > collision.transform.position.y)
        // {
        // transform.position.x = collision.transform.position.x;
        // transform.position.y = collision.transform.position.y;
        // transform.position.z = collision.transform.position.z;
        if (finished == false)
        {
            Vector3 newPosition = new Vector3(collision.transform.position.x, collision.transform.position.y + 0.2F, collision.transform.position.z);
            transform.position = newPosition;
            transform.parent = collision.transform;
            scriptToDeactivate.enabled = false;
            rb.isKinematic = true;
            finished = true;
        }
        // }
        // You can now do something with 'otherObject'.
    }
}
