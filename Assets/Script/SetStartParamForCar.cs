using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartParamForCar : MonoBehaviour
{
    private void OnEnable()
    {
        Camera.main?.GetComponent<CameraLookAt>().SetTarget(transform);
        BrakeButton.Car = GetComponent<CarController>();
    }
}
