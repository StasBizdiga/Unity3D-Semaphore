﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //Check Colliders, randomly choose one and instantiate a random object from a public prefab list 
    public float interval = 5; //for 5 seconds
    float timer;
    
    [Header("Car Prefabs")]
    public List<GameObject> car = new List<GameObject>();

    [Header("Spawning Colliders")]
    public List<GameObject> spawn = new List<GameObject>();

    int location, type; // location: 0 to 7, since (2 lanes * N,S,W,E); type: 0 to numOfCarPrefabs
                        // location - used to determine where the cars will be spawned from
                        // type - used to determine the type of car to be spawned

    void Start()
    {
        timer = Time.time + interval;
    }


    void Update()
    {
        if (Input.GetKey("[*]") && interval > 2.0f) { interval -= 0.5f; } // Decrease to min 0.5s per interval
        else if (Input.GetKey("[/]") && interval < 30.0f) { interval += 0.5f; } // Increase max 60s per interval

        if (Time.time >= timer) //every interval do:
        {
            SpawnCar();
            timer += interval; //set the timer again
        }
    }


    void SpawnCar()
    {
        location += 1; 
        type = Random.Range(0, car.Count);
        if (location == 8) { location = 0; }
        Instantiate(car[type], spawn[location].transform.position, spawn[location].transform.rotation);
        
    }
}
