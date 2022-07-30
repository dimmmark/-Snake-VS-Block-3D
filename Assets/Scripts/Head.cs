using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
   private Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    public void Move(Vector3 newPosition)
    {
        rb.MovePosition(newPosition);
    }
}
