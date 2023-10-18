using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFood : MonoBehaviour
{
    public GameObject[] food;
    public Transform orientation;
    private float lastTime;
    void Start()
    {
        lastTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        //If at least one second has passed spawn food.
        if ((Time.fixedTime - lastTime) >= 2)
        {
            lastTime = Time.fixedTime;
            //Chose food item at random.
            int randomIndex = Random.Range(0, food.Length);
            //Choose a random spawn spot based on the spawn sphere.
            Vector3 randomPosition = new Vector3(Random.Range(-10 + orientation.position.x, 11 + orientation.position.x), 15, Random.Range(-10 + orientation.position.z, 10 + orientation.position.z));
            //Spawn the food item.
            Instantiate(food[randomIndex], randomPosition, Quaternion.Euler(-90, 0, 0));
        }
    }
}
