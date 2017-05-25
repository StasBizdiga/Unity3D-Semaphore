using UnityEngine;

public class control : MonoBehaviour {
 
     public float acceleration;
public float steering;
private Rigidbody rb;
    public GameObject BrkLight1, BrkLight2;
    void Start()
{
    rb = GetComponent<Rigidbody>();
}

void FixedUpdate()
{



        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * acceleration);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.forward * -acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -steering * ( rb.velocity.magnitude / 5.0f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * steering * (rb.velocity.magnitude / 5.0f));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            BrkLight1.gameObject.SetActive(true); BrkLight2.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            BrkLight1.gameObject.SetActive(false); BrkLight2.gameObject.SetActive(false);
        }

    }
}
