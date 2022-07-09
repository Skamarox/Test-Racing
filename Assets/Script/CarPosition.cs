using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPosition : MonoBehaviour
{
    private Vector3 StartPosition;
    private Quaternion StartRotation;

    private void Awake()
    {
        StartRotation = transform.rotation;
        StartPosition = transform.position;
    }

    private void OnEnable()
    {
        SetPosAndRot();
    }

    private void Update()
    {
        if(transform.position.y < -0.6)
            SetPosAndRot();
    }

    private void SetPosAndRot()
    {
        transform.position = StartPosition;
        transform.rotation = StartRotation;
    }
}
