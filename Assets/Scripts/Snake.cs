using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    [SerializeField] Head _head;
    [SerializeField] float _speed;
    [SerializeField] float _speedR;
    private Vector3 _previosMousePosition;
    [SerializeField] private Transform Head;
    private List<Segment> _tail;
    private SnakeGenerator _tailGenerator;
   
    void Awake()
    {
        _tailGenerator = GetComponent<SnakeGenerator>();
        _tail = _tailGenerator.Generate();
    }

    private void FixedUpdate()
    {
        _head.transform.position += _head.transform.forward * _speed * Time.fixedDeltaTime;
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previosMousePosition;
            _head.transform.position += _head.transform.right * _speedR* delta.x * Time.fixedDeltaTime;
           
           // Debug.Log(delta);
        }


        _previosMousePosition = Input.mousePosition;
    }
}
