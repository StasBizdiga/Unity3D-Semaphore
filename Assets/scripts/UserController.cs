using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {

    public List<GameObject> cam = new List<GameObject>();
    private int current;
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.R)) { Application.LoadLevel(Application.loadedLevel); } // R - reset
        if (Input.GetKeyDown("escape")) {Application.Quit();}                                // esc - exit
        if (Input.GetKeyDown(KeyCode.C))
        {
            current += 1;
            if (current > cam.Count-1) { current = 0; }
            cam[0].gameObject.SetActive(false);
            cam[1].gameObject.SetActive(false);
            cam[2].gameObject.SetActive(false);
            cam[3].gameObject.SetActive(false);
            cam[current].gameObject.SetActive(true); 
        }

    }
}
