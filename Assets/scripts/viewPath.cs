using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewPath : MonoBehaviour
{
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        foreach (var item in pathTransforms)
        {
            if (item != transform)
            {
                nodes.Add(item);
            }
        }

        Vector3 currentNode = Vector3.zero;
        Vector3 previousNode = Vector3.zero;
        for (int i = 1; i < nodes.Count; i++)
        {
            currentNode = nodes[i].position;
            previousNode = nodes[i - 1].position;
            Gizmos.DrawLine(previousNode, currentNode);
        }
    }
}
