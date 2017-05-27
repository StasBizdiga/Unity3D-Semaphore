using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittentSignals : MonoBehaviour {

    public float interval = 0.5f; 
    float timer;

    public GameObject light1, light2; 
    bool flip = false;
    void Start()
    {
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
        light1.gameObject.SetActive(flip);
        flip = !flip;
        light2.gameObject.SetActive(flip);
        }
}
