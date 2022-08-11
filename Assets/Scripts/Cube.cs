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



    void Start()
    {
        FillingUpdated?.Invoke(LeftToFill);
        AudioSourceBoom = GetComponent<AudioSource>();
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
