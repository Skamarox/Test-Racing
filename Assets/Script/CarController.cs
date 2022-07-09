using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform leftWheelModel;
    public Transform rightWheelModel;
    public bool motor;
    public bool steering;
}

public class CarInfo : MonoBehaviour
{
    [SerializeField] protected float MaxMotorTorque;
    [SerializeField] protected float BrakeTorqueValue;
    protected float MaxSteeringAngle = 30f;
    [SerializeField] protected bool IsBreaking = false;
    protected float MotorValue;
    protected float SteeringAngle;
}

public class CarController : CarInfo
{
    [SerializeField] private Joystick Controller;
    [SerializeField] private List<AxleInfo> AxleInfo;
    private Rigidbody rb;
    private Motor CarMotor = new Motor();
    private Steering CarSteering = new Steering();
    private VisualWheels Visual = new VisualWheels();
    private float x = 10.0f;
    private int y = 15;
    private int z = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }

    private void FixedUpdate()
    {
        CarControllParam();
        foreach (AxleInfo axleInfo in AxleInfo)
        {
            axleInfo.leftWheel.ConfigureVehicleSubsteps(x, y, z);
            if (axleInfo.motor)
            {
                CarMotor.Run(axleInfo, MotorValue);
                float brakeTorqueValue = IsBreaking ? BrakeTorqueValue : 0f;
                CarMotor.Stop(axleInfo, brakeTorqueValue);
            }

            if(axleInfo.steering)
            CarSteering.UpdateWheelAngle(axleInfo, SteeringAngle);

            Visual.Update(axleInfo);
        }
    }
    private void CarControllParam()
    {
        MotorValue = MaxMotorTorque * Controller.Vertical;
        SteeringAngle = MaxSteeringAngle * Controller.Horizontal;
    }

    public void Brake(bool value)
    {
        IsBreaking = value;
    }
}

public class Motor
{
    public void Run(AxleInfo info, float MotorValue)
    {
        info.leftWheel.motorTorque = MotorValue;
        info.rightWheel.motorTorque = MotorValue;
    }

    public void Stop(AxleInfo info, float BrakeTorqueValue)
    {
        info.leftWheel.brakeTorque = BrakeTorqueValue;
        info.rightWheel.brakeTorque = BrakeTorqueValue;
    }
}

public class Steering
{
    public void UpdateWheelAngle(AxleInfo axleInfo, float SteeringAngle)
    {
        axleInfo.leftWheel.steerAngle = SteeringAngle;
        axleInfo.rightWheel.steerAngle = SteeringAngle;
    }
}

public class VisualWheels
{
    public void Update(AxleInfo axleInfo)
    {
        ApplyValue(axleInfo.leftWheel, axleInfo.leftWheelModel);
        ApplyValue(axleInfo.rightWheel, axleInfo.rightWheelModel);
    }

    private void ApplyValue(WheelCollider collider, Transform wheel)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        wheel.position = position;
        wheel.rotation = rotation;
    }
}