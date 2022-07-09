using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToCamera : MonoBehaviour
{
    private void OnEnable()
    {
        Camera.main?.GetComponent<CameraLookAt>().SetTarget(transform);
    }
}
