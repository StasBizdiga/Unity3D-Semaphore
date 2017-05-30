using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpWallTrigger : MonoBehaviour
{
    public GameObject wall;

    void OnTriggerStart(Collider other)
    {
        if (other.tag == "Hooman")
        {
            wall.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hooman")
        {
            wall.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hooman")
        {
            wall.SetActive(false);
        }
    }
}
