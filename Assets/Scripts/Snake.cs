using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    [SerializeField] Head _head;
    [SerializeField] float _speed;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _head.transform.position = _head.transform.position + _head.transform.forward * _speed * Time.fixedDeltaTime;
    }
}
