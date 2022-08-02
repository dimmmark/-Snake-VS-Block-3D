 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Head : MonoBehaviour
{
    public event UnityAction CubeCollided;



    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube))
        {
            CubeCollided?.Invoke();
            cube.Fill();
        }
    }

}
