using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
   [SerializeField] Head head;
    [SerializeField] float _speed;
    [SerializeField] Vector3 offset;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, head.transform.position + offset, _speed * Time.fixedDeltaTime);
    }
}
