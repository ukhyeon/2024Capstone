// 화살표키로 이동. 좌우 == 회전, 위아래 == 앞뒤
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControlKeyboard : MonoBehaviour
{

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private float motorForce;
    [SerializeField] private float horizontalRate;

    //¾Õ ¹ÙÄû
    [SerializeField] private WheelCollider FLwheel;
    [SerializeField] private WheelCollider FRwheel;

    //µÞ ¹ÙÄû
    [SerializeField] private WheelCollider BLwheel;
    [SerializeField] private WheelCollider BRwheel;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
    }

    private void HandleMotor()
    {
        FLwheel.motorTorque = (verticalInput + horizontalInput * horizontalRate) * motorForce;
        FRwheel.motorTorque = (verticalInput - horizontalInput * horizontalRate) * motorForce;
    }

}
