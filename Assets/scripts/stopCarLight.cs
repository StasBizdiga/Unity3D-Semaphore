using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCarLight : MonoBehaviour
{
    private CarEngine carScript;
    void OnTriggerEnter(Collider other)
    {
        carScript = other.gameObject.GetComponent<CarEngine>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Car")
        {
            carScript.isBraking = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car")
        {
            carScript.isBraking = false;
        }
    }
}
