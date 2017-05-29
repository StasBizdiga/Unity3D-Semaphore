using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpWallTrigger : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;

    public GameObject enterZone1;
    public GameObject enterZone2;

    private bool disabledZone = false;

    void OnTriggerStart(Collider other)
    {
        if (other.tag == "Hooman")
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hooman")
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            if (enterZone1.activeSelf)
            {
                enterZone1.SetActive(false);
                enterZone2.SetActive(false);
                disabledZone = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hooman")
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
        }
        if (disabledZone)
        {
            enterZone1.SetActive(true);
            enterZone2.SetActive(true);
        }

    }
}
