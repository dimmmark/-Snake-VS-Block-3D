using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int _count;
    public int _fill;
    public TMP_Text textCiont;
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

    private void Update()
    {
        textCiont.text = _count.ToString();
    }

}
