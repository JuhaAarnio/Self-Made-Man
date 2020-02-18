using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerLawnmowerMovement : MonoBehaviour
{
    [SerializeField]
    WheelJoint2D rearWheel;
    [SerializeField]
    float enginePower;
    JointMotor2D jointMotor;

    // Update is called once per frame
    void Update()
    {
        jointMotor.maxMotorTorque = 10000f;
        if (Input.GetKey(KeyCode.D))
        {
            jointMotor.motorSpeed = enginePower;
            rearWheel.motor = jointMotor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            jointMotor.motorSpeed = -enginePower;
            rearWheel.motor = jointMotor;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            jointMotor.motorSpeed = 0f;
            rearWheel.motor = jointMotor;
        }
    }

}
