using UnityEngine;

public class BoundaryKiller : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        // Destroy object if its layer is CAR once it leaves the trigger area
        if (other.gameObject.tag == "Car")
        { Destroy(other.gameObject); }
    }
}
