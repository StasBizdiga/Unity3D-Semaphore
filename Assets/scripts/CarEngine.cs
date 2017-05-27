using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public bool is_specialCar; 
    public string comesFrom;
    int pathChoice; // random choice
    public Transform path;
    private List<Transform> nodes = new List<Transform>();
    private int currentNode = 0;
    public float maxSteerAngle = 45.0f;
    public float maxMotorTorque = 1000.0f;
    public float currentSpeed;
    public float maxSpeed = 1000f;
    public bool isBraking = false;

    public WheelCollider frontLeftW;
    public WheelCollider frontRightW;
    public WheelCollider backLeftW;
    public WheelCollider backRightW;
    public float maxBrakeTorque = 150f;

    public Light stopLight1;
    public Light stopLight2;

    [Header("Sensors")]
    public float sensorLength = 2f;
    public float frontSensorPos = 0f;
    public float frontSideSensorPos = 0.21f;
    public float frontSensorAngle = 30f;

    void Start()
    {
        if (this.transform.position.x > 5f) { comesFrom = "East"; }
        else if (this.transform.position.z > 5f) { comesFrom = "North"; }
        else if (this.transform.position.x < -5f) { comesFrom = "West"; }
        else if (this.transform.position.z < -5f) { comesFrom = "South"; } 
        pathChoice = Random.Range(0,3); //
        path = GameObject.FindWithTag(comesFrom).transform; //
        currentNode = 0;
        Transform[] pathTransforms = path.GetChild(pathChoice).GetComponentsInChildren <Transform>(); //
        nodes = new List<Transform>();
        foreach (var item in pathTransforms)
        {
            if (item != path.GetChild(pathChoice).transform)
            {
                nodes.Add(item);
            }
        }
    }

    private void FixedUpdate()
    {
        Sensors();
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
    }
    private void Sensors()
    {
        RaycastHit hit = new RaycastHit();
        Vector3 sensorStartingPos = transform.position;
        sensorStartingPos.z += frontSensorPos;
        isBraking = false;  //
        if (Physics.Raycast(sensorStartingPos, transform.forward, out hit, sensorLength)) //front center sensor
        {
            Debug.DrawLine(sensorStartingPos, hit.point);
            isBraking = true;
        }

        sensorStartingPos.x += frontSideSensorPos;
        if (Physics.Raycast(sensorStartingPos, transform.forward, out hit, sensorLength)) //front right sensor
        {
            Debug.DrawLine(sensorStartingPos, hit.point);
            isBraking = true;
        }


        if (Physics.Raycast(sensorStartingPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength)) //front right angle sensor
        {
            Debug.DrawLine(sensorStartingPos, hit.point);
            isBraking = true;
        }

        sensorStartingPos.x -= 2 * frontSideSensorPos;
        if (Physics.Raycast(sensorStartingPos, transform.forward, out hit, sensorLength)) //front left sensor
        {
            Debug.DrawLine(sensorStartingPos, hit.point);
            isBraking = true;
        }


        if (Physics.Raycast(sensorStartingPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength)) //front left angle sensor
        {
            Debug.DrawLine(sensorStartingPos, hit.point);
            isBraking = true;
        }
    
    }
    private void Braking()
    {
        if (isBraking)
        {
            stopLight1.enabled = true;
            stopLight2.enabled = true;
            backLeftW.brakeTorque = maxBrakeTorque;
            backRightW.brakeTorque = maxBrakeTorque;
        }
        else
        {
            stopLight1.enabled = false;
            stopLight2.enabled = false;
            backLeftW.brakeTorque = 0;
            backRightW.brakeTorque = 0;
        }
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
        {
            currentNode = (currentNode < nodes.Count - 1) ? currentNode + 1 : currentNode;
        }
    }

    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * frontLeftW.radius * frontLeftW.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed && !isBraking)
        {
            frontLeftW.motorTorque = maxMotorTorque;
            frontRightW.motorTorque = maxMotorTorque;
        }
        else
        {
            frontLeftW.motorTorque = 0;
            frontRightW.motorTorque = 0;
        }
    }

    private void ApplySteer()
    {
        Vector3 relVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relVector.x / relVector.magnitude) * maxSteerAngle;
        frontLeftW.steerAngle = newSteer;
        frontRightW.steerAngle = newSteer;
    }
}
