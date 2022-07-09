using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float x;
    [SerializeField] private float y;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * x, rb.velocity.y, joystick.Vertical * y);
    }
}
