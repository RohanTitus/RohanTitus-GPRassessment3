﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject[] cars = null;
    [SerializeField] private GameObject[] platforms = null;

    private float carSpawnTimer;
    private float platformSpawnTimer;
    
    // Start is called before the first frame update
    void Start() {
        carSpawnTimer = 0;
        platformSpawnTimer = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time - carSpawnTimer > 1.5f) spawnCars();
        if (Time.time - platformSpawnTimer > 1.5f) spawnPlatforms();
    }

    private void spawnCars() { 
        Instantiate(cars[0], new Vector3(-11f, -1.15f, 0f), Quaternion.identity);
        Instantiate(cars[1], new Vector3(11f, -2.34f, 0f), Quaternion.identity);
        Instantiate(cars[2], new Vector3(-11f, -3.5f, 0f), Quaternion.identity);
        carSpawnTimer = Time.time;
    }

    private void spawnPlatforms() {
        Instantiate(platforms[0], new Vector3(-11f,  3.05f, 0f), Quaternion.identity);
        Instantiate(platforms[1], new Vector3(11f, 1.96f, 0f), Quaternion.identity);
        Instantiate(platforms[2], new Vector3(-11f, 0.87f, 0f), Quaternion.identity);
        platformSpawnTimer = Time.time;
    }
}