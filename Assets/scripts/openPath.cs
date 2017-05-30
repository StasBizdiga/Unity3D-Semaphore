using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPath : MonoBehaviour
{
    public GameObject path;
    private bool hasDisabledPath = false;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hooman" && path.activeSelf)
        {
            path.SetActive(false);
            hasDisabledPath = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hooman" && hasDisabledPath)
        {
            path.SetActive(true);
        }
    }

}
