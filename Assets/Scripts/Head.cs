 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Head : MonoBehaviour
{
    public event UnityAction CubeCollided;
    public event UnityAction<int> BonusCollected;



    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube))
        {
            CubeCollided?.Invoke();
            cube.Fill();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.TryGetComponent(out Bonus bonus))
        {
            BonusCollected?.Invoke(bonus.Collect());

        }
    }

}
