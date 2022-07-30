using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _count;
    private int _fill;
    void Start()
    {
        
    }

    public void Fill()
    {
        _fill++;
        Debug.Log(_fill);
        if (_fill == _count)
        {
            Destroy(gameObject);
        }
    }
}
