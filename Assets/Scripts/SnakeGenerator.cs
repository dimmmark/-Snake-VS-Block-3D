using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerator : MonoBehaviour
{

    [SerializeField] private Segment _segmentTemplate;
    // public TMP_Text textSgmentCount;
    public List<Segment> Generate(int count)
    {
        List<Segment> tail = new List<Segment>();
        for (int i = 0; i < count; i++)
        {
            tail.Add(Instantiate(_segmentTemplate, transform));
        }
        return tail;
    }




}
