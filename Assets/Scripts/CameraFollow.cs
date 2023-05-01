using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        Vector3 position = _target.position;
        position.z = transform.position.z;
    }
}
