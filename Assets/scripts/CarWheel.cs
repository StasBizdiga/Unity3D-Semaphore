using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    public WheelCollider wheelCollider;
    private Vector3 wheelPos = new Vector3();
    private Quaternion wheelRotation = new Quaternion();


	void Update ()
    {
        wheelCollider.GetWorldPose(out wheelPos, out wheelRotation);
        wheelRotation *= Quaternion.Euler(0f, 0f, -90f);
        transform.position = wheelPos;
        transform.rotation = Quaternion.Lerp(transform.rotation, wheelRotation, Time.deltaTime * 3.0f);
    }
}
