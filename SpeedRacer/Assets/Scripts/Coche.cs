using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float anguloGiro;

    // Referencias a colliders y transform de las ruedas
    public WheelCollider frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;
    public Transform frontLeftTransform, frontRightTransform, rearLeftTransform, rearRightTransform;

    public float maxAnguloGiro;
    public float maxMotorTorque;

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Girar()
    {
        anguloGiro = maxAnguloGiro * horizontalInput;
        frontLeftWheel.steerAngle = anguloGiro;
        frontRightWheel.steerAngle = anguloGiro;
    }

    private void Acelerar()
    {
        frontLeftWheel.motorTorque = maxMotorTorque * verticalInput;
        frontRightWheel.motorTorque = maxMotorTorque * verticalInput;
    }

    private void ActualizarRuedas()
    {
        ActualizarRuedas(frontLeftWheel, frontLeftTransform);
        ActualizarRuedas(frontRightWheel, frontRightTransform);
        ActualizarRuedas(rearLeftWheel, rearLeftTransform);
        ActualizarRuedas(rearRightWheel, rearRightTransform);
    }

    private void ActualizarRuedas(WheelCollider c, Transform t)
    {
        Vector3 posicion = t.position;
        Quaternion rotacion = t.rotation;
        c.GetWorldPose(out posicion, out rotacion);

        t.position = posicion;
        t.rotation = rotacion;
    }

    private void FixedUpdate()
    {
        GetInput();
        Girar();
        Acelerar();
        ActualizarRuedas();
    }
}
