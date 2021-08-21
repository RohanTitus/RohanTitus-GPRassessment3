using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject[] cars = null;

    private float carSpawnTimer;
    // Start is called before the first frame update
    void Start() {
        carSpawnTimer = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time - carSpawnTimer > 1.5f) spawnCars();
    }

    private void spawnCars() {
        Instantiate(cars[0], new Vector3(-11f, -1.15f, 0f), Quaternion.identity);
        Instantiate(cars[1], new Vector3(11f, -2.34f, 0f), Quaternion.identity);
        Instantiate(cars[2], new Vector3(-11f, -3.5f, 0f), Quaternion.identity);
        carSpawnTimer = Time.time;
    }
}