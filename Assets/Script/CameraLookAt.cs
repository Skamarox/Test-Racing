using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Transform Target;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float RotationSpeed;
    private Transform myTransform;

    private void Start()
    {
        myTransform = transform;
    }

    public void SetTarget(Transform Target) => this.Target = Target;

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        Vector3 targetPosition = Target.TransformPoint(Offset);
        myTransform.position = Vector3.Lerp(myTransform.position, targetPosition, MoveSpeed * Time.fixedDeltaTime);
    }
    private void HandleRotation()
    {
        Vector3 direction = Target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, rotation, RotationSpeed * Time.fixedDeltaTime);
    }
}
