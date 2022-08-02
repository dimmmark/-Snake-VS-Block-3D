using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{

    [SerializeField] Head _head;
    [SerializeField] float _speed;
    [SerializeField] float _speedR;
    private Vector3 _previosMousePosition;
    [SerializeField] private Transform Head;
    private List<Segment> _tail;
    private SnakeGenerator _tailGenerator;
    [SerializeField] private float _tailConnect;

    public event UnityAction<int> SizeUpdated;
    void Awake()
    {
        _tailGenerator = GetComponent<SnakeGenerator>();
        _tail = _tailGenerator.Generate();
        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        _head.CubeCollided += OnCubeCillided;
    }

    private void OnDisable()
    {
        _head.CubeCollided -= OnCubeCillided;
    }
    private void OnCubeCillided()
    {
        Segment deletedSegment = _tail[_tail.Count - 1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);

        SizeUpdated?.Invoke(_tail.Count);
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
        Vector3 previosPosition = _head.transform.position;
        foreach (Segment segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector3.Lerp(segment.transform.position, previosPosition,_tailConnect * Time.fixedDeltaTime);
            previosPosition = tempPosition;
        }
        
       
    }
}
