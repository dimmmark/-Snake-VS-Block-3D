using TMPro;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    private Cube _cube;
    void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        _cube.FillingUpdated += OnFillingUpdated;
    }

    private void OnDisable()
    {
        _cube.FillingUpdated -= OnFillingUpdated;
    }

    private void OnFillingUpdated(int leftToFill)
    {
        _view.text = leftToFill.ToString();
    }
}
