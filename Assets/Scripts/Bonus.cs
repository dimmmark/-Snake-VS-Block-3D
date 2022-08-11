using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private int _bonusSize;
   


    void Start()
    {
        _view.text = _bonusSize.ToString();
     
    }

    public int Collect()
    {
       
        Destroy(gameObject);
        return _bonusSize;
        
    }
}
