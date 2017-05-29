using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianWalk : MonoBehaviour
{
    public Transform path;
    private List<Transform> nodes = new List<Transform>();
    private int currentNode = 0;

    [Header("Sensors")]
    public float sensorLength = 2f;
    public float frontSensorPos = 0f;

    private NavMeshAgent agent = new NavMeshAgent();
    public GameObject leftHand;
    public GameObject rightHand;
    private Animator leftHandAnim;
    private Animator rightHandAnim;

    void Start()
    {
        currentNode = 0;
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
        leftHandAnim = leftHand.GetComponent<Animator>();
        rightHandAnim = rightHand.GetComponent<Animator>();
        agent.updateRotation = true;
        nodes = new List<Transform>();

        foreach (var item in pathTransforms)
        {
            if (item != path.transform)
            {
                nodes.Add(item);
            }
        }
    }

    private void FixedUpdate()
    {
        CheckWaypointDistance();
        Sensors();
    }
    
    private void CheckWaypointDistance()
    {
        if (agent.remainingDistance < 0.5f)
        {
            currentNode = (currentNode < nodes.Count - 1) ? currentNode + 1 : currentNode;
            agent.destination = nodes[currentNode].position;
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
            agent.isStopped = true;
            rightHandAnim.enabled = false;
            leftHandAnim.enabled = false;
            Debug.DrawLine(sensorStartingPos, hit.point);
        }
        else
        {
            agent.isStopped = false;
            rightHandAnim.enabled = true;
            leftHandAnim.enabled = true;
        }
    }
}
