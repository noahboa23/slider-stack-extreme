using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackHeight : MonoBehaviour
{
    public float height = 0.1F;
    public float nextTopping()
    {
        height += 0.1F;
        return height;
    }
    public void reset()
    {
        height = 0.1F;
    }
}
