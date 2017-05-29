using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    // This should be set to degrees per second
    public float rotateSpeed = 90.0f;
    public Vector3 axisToRotate = new Vector3(0f,1f,0f);
    Vector3 rot;
    void Start()
    { rot = transform.eulerAngles; }
    void Update()
    {
        rot += axisToRotate * rotateSpeed * Time.deltaTime;

        if ((rot.x > 360) || (rot.x < -360))
            rot.x = 0;
        if ((rot.y > 360) || (rot.y < -360))
            rot.y = 0;
        if ((rot.z > 360) || (rot.z < -360))
            rot.z = 0;

       transform.eulerAngles = rot;

    }

}
