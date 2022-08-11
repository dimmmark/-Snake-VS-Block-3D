using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    public int _count;
    public int _fill;
    public TMP_Text textCiont;
    
    public int LeftToFill => _count - _fill;
    public UnityAction<int> FillingUpdated;
    AudioSource AudioSourceBoom;
    MeshRenderer ColorMat;



    void Start()
    {
        FillingUpdated?.Invoke(LeftToFill);
        AudioSourceBoom = GetComponent<AudioSource>();
        ColorMat = GetComponent<MeshRenderer>();
        if(_count <= 2)
        ColorMat.material.color = Color.white;
        else if (_count <= 5)
            ColorMat.material.color = Color.yellow;
        else if (_count <= 10)
            ColorMat.material.color = Color.green;
        else if(_count <= 20)
            ColorMat.material.color = Color.red;
        else if(_count <= 30)
            ColorMat.material.color = Color.gray;
        else if (_count <= 40)
            ColorMat.material.color = Color.black;
    }

    public void Fill()
    {
        AudioSourceBoom.Play();
        _fill++;
        FillingUpdated?.Invoke(LeftToFill);
        //Debug.Log(_fill);
        if (_fill == _count)
        {
            Destroy(gameObject);

        }
    }





}
