using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{




    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube))
        {
            cube.Fill();
        }
    }

}
