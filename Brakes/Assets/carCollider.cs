using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCollider : MonoBehaviour
{
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelBL;
    public WheelCollider WheelBR;

    public GameObject FL;
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;

    public float topSpeed = 250f;
    public float maxTorque;
    public float maxSteerAngle = 45f;
    public float currentSpeed;
    public float maxBrakeTorque;

    public float forward;
    private float turn;
    private float brake;

    private Rigidbody car_body;

    private void Awake()
    {
        car_body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        forward = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");
        //brake = Input.GetAxis("Space");

        WheelFL.steerAngle = maxSteerAngle * turn;
        WheelFR.steerAngle = maxSteerAngle * turn;

        
        //print(currentSpeed);

        if (currentSpeed < topSpeed)
        {
            WheelBL.motorTorque = maxTorque * forward;
            WheelBR.motorTorque = maxTorque * forward;
        }

        WheelBL.brakeTorque = maxBrakeTorque * brake;
        WheelBR.brakeTorque = maxBrakeTorque * brake;
        WheelFL.brakeTorque = maxBrakeTorque * brake;
        WheelFR.brakeTorque = maxBrakeTorque * brake;
    }

    private void Update()
    {
        currentSpeed = 2 * Mathf.PI * WheelFL.radius * WheelFL.rpm * 60 / 1000;
        print("car Speed" + currentSpeed);
        Quaternion flq;
        Vector3 flv;
        WheelFL.GetWorldPose(out flv, out flq);
        FL.transform.position = flv;
        FL.transform.rotation = flq;

        Quaternion blq;
        Vector3 blv;
        WheelBL.GetWorldPose(out blv, out blq);
        BL.transform.position = blv;
        BL.transform.rotation = blq;

        Quaternion frq;
        Vector3 frv;
        WheelFR.GetWorldPose(out frv, out frq);
        FR.transform.position = frv;
        FR.transform.rotation = frq;

        Quaternion brq;
        Vector3 brv;
        WheelBR.GetWorldPose(out brv, out brq);
        BR.transform.position = brv;
        BR.transform.rotation = brq;

    }
}
