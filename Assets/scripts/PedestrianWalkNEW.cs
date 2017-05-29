using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianWalNEW : MonoBehaviour
{
    int comesFrom;
    int pathChoice; // random choice
    public Transform path;
    private List<Transform> nodes = new List<Transform>();
    private int currentNode = 0;

    [Header("Sensors")]
    public float sensorLength = 2f;
    public float frontSensorPos = 0f;
    
    public GameObject leftHand;
    public GameObject rightHand;
    private Animator leftHandAnim;
    private Animator rightHandAnim;
    
    public float maxSpeed = 100f;
    public bool isWaiting = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (this.transform.position.x > 5f) { comesFrom = 1; }
        else if (this.transform.position.z > 5f) { comesFrom = 0; }
        else if (this.transform.position.x < -5f) { comesFrom = 3; }
        else if (this.transform.position.z < -5f) { comesFrom = 2; }
        pathChoice = Random.Range(0, 2); //
        path = GameObject.FindWithTag("HumanPath").transform; //
        path = path.GetChild(comesFrom).transform;
        currentNode = 0;
        Transform[] pathTransforms = path.GetChild(pathChoice).GetComponentsInChildren<Transform>(); //
        nodes = new List<Transform>();

        leftHandAnim = leftHand.GetComponent<Animator>();
        rightHandAnim = rightHand.GetComponent<Animator>();
        
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
        CheckWaypointDistance();
        SpeedLimit();
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
        {
            currentNode = (currentNode < nodes.Count - 1) ? currentNode + 1 : currentNode;
        }
    }

    private void Sensors()
    {
        RaycastHit hit = new RaycastHit();
        Vector3 sensorStartingPos = transform.position;
        sensorStartingPos.z += frontSensorPos;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(sensorStartingPos, fwd, out hit, sensorLength))
        {
            isWaiting = true;
            rightHandAnim.enabled = false;
            leftHandAnim.enabled = false;
            Debug.DrawLine(sensorStartingPos, hit.point);
        }
        else
        {
            isWaiting = false;
            rightHandAnim.enabled = true;
            leftHandAnim.enabled = true;
        }
    }

    private void Drive()
    {
        if (!isWaiting)
        { rb.AddForce(nodes[currentNode].transform.position-transform.position*maxSpeed);}
    }

    private void ApplySteer()
    {
        transform.LookAt(nodes[currentNode].transform.position);
    }

    void SpeedLimit()
    {
        if (rb.velocity.magnitude > maxSpeed)
         {
                rb.velocity = rb.velocity.normalized * maxSpeed;
         }}
}
