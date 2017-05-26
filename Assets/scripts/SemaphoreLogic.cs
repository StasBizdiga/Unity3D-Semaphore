using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaphoreLogic : MonoBehaviour {

    public GameObject L1,L2,L3,L4,L5,L6,L7,L8; // Light: odd-green, even-red
    static bool VerticalFlowAllowed;
    float interval = 5; //for 5 seconds
    float timer;

	void Start () {
        VerticalFlowAllowed = false;
        timer = Time.time + interval;
    }

	
	// Update is called once per frame
	void Update () {

        if (Time.time >= timer) //every interval do:
        {
            ChangeLights();
            timer += interval; //set the timer again
                                          
        }
    }
    void ChangeLights()
    {
        if (VerticalFlowAllowed)
        {
            L1.gameObject.SetActive(true);
            L2.gameObject.SetActive(false);
            L3.gameObject.SetActive(true);
            L4.gameObject.SetActive(false);
            L5.gameObject.SetActive(false);
            L6.gameObject.SetActive(true);
            L7.gameObject.SetActive(false);
            L8.gameObject.SetActive(true);
        }
        else
        {
            L1.gameObject.SetActive(false);
            L2.gameObject.SetActive(true);
            L3.gameObject.SetActive(false);
            L4.gameObject.SetActive(true);
            L5.gameObject.SetActive(true);
            L6.gameObject.SetActive(false);
            L7.gameObject.SetActive(true);
            L8.gameObject.SetActive(false);
        }
    VerticalFlowAllowed = !VerticalFlowAllowed;

    }
}
