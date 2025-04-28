using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Netcode;

public class CarController : MonoBehaviour
{
    public enum CarType
    {
        FrontWheelDrive,
        BackWheelDrive,
        AllWheelDrive
    }
    public CarType carType = CarType.AllWheelDrive;

    public enum ControlMode
    {
        Keyboard,
        Button
    };

    public ControlMode control;

    [Header("Wheel GameObjects (Meshes)")]
    public GameObject FrontLeftWheel;
    public GameObject FrontRightWheel;
    public GameObject BackLeftWheel;
    public GameObject BackRightWheel;

    [Header("Wheel GameObjects (Collider)")]
    public WheelCollider FrontLeftWheelCollider;
    public WheelCollider FrontRightWheelCollider;
    public WheelCollider BackLeftWheelCollider;
    public WheelCollider BackRightWheelCollider;

    [Header("Movement Variables")]
    private float currentSpeed;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maximumSpeed;
    public float brakePower;
    public Transform COM;
    float carSpeed;
    float carSpeedConverted;
    float MotorTorque;
    float tireAngle;
    float vertical = 0f;
    float horizontal = 0f;
    bool handBrake = false;
    Rigidbody carRigidBody;

    [Header("Lap")]
    public int maxLaps;
    public int currentLap;

    private void Start()
    {
        carRigidBody = GetComponent<Rigidbody>();

        if (carRigidBody != null)
        {
            carRigidBody.centerOfMass = COM.localPosition;
        }

        maxLaps = FindObjectOfType<LapSystem>().maxLaps;
    }

    private void FixedUpdate()
    {
        GetInput();
        CalculateCarMovement();
        CalculateSteering();

        ApplyTransformToWheels();
    }

    public void MoveInput(float moveInput)
    {
        vertical = moveInput;
    }

    public void SteeringInput(float moveInput)
    {
        horizontal = moveInput;
    }

    void GetInput()
    {
        if (control == ControlMode.Keyboard)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
    }

    void CalculateCarMovement()
    {
        carSpeed = carRigidBody.linearVelocity.magnitude;
        carSpeedConverted= Mathf.Round(carSpeed * 3.6f);

        //Braking
        if (Input.GetKey(KeyCode.Space))
        {
            handBrake = true;
        }
        else
        {
            handBrake = false;
        }
        if (handBrake)
        {
            MotorTorque = 0f;
            ApplyBrake();
        }
        else
        {
            ReleaseBrake();

            if (carSpeedConverted < maximumSpeed)
            {
                MotorTorque = maxMotorTorque * vertical;
            }
            else
            {
                MotorTorque = 0f;
            }
        }

        ApplyTorque();
    }

    void CalculateSteering()
    {
        tireAngle = maxSteeringAngle * horizontal;
        FrontLeftWheelCollider.steerAngle = tireAngle;
        FrontRightWheelCollider.steerAngle = tireAngle;
    }

    void ApplyTorque()
    {
        if (carType == CarType.FrontWheelDrive)
        {
            FrontLeftWheelCollider.motorTorque = MotorTorque;
            FrontRightWheelCollider.motorTorque = MotorTorque;
        }
        else if (carType == CarType.BackWheelDrive)
        {
            BackLeftWheelCollider.motorTorque = MotorTorque;
            BackRightWheelCollider.motorTorque = MotorTorque;
        }
        else if (carType == CarType.AllWheelDrive)
        {
            FrontLeftWheelCollider.motorTorque = MotorTorque;
            FrontRightWheelCollider.motorTorque = MotorTorque;
            BackLeftWheelCollider.motorTorque = MotorTorque;
            BackRightWheelCollider.motorTorque = MotorTorque;
        }
    }

    void ApplyBrake()
    {
        FrontLeftWheelCollider.brakeTorque = brakePower;
        FrontRightWheelCollider.brakeTorque = brakePower;
        BackLeftWheelCollider.brakeTorque = brakePower;
        BackRightWheelCollider.brakeTorque = brakePower;
    }

    void ReleaseBrake()
    {
        FrontLeftWheelCollider.brakeTorque = 0;
        FrontRightWheelCollider.brakeTorque = 0;
        BackLeftWheelCollider.brakeTorque = 0;
        BackRightWheelCollider.brakeTorque = 0;
    }

    public void ApplyTransformToWheels()
    {
        Vector3 position;
        Quaternion rotation;

        FrontLeftWheelCollider.GetWorldPose(out position, out rotation);
        FrontLeftWheel.transform.position = position;
        FrontLeftWheel.transform.rotation = rotation;

        FrontRightWheelCollider.GetWorldPose(out position, out rotation);
        FrontRightWheel.transform.position = position;
        FrontRightWheel.transform.rotation = rotation;

        BackLeftWheelCollider.GetWorldPose(out position, out rotation);
        BackLeftWheel.transform.position = position;
        BackLeftWheel.transform.rotation = rotation;

        BackRightWheelCollider.GetWorldPose(out position, out rotation);
        BackRightWheel.transform.position = position;
        BackRightWheel.transform.rotation = rotation;
    }

    public void IncreaseLap()
    {
        currentLap++;
        Debug.Log(gameObject.name + " has completed lap " + currentLap + " out of " + maxLaps);
    }
}
