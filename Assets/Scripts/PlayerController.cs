using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GameObject finishUI = null;
    
    private Vector3 startPosition;
    private Transform startParent;
    private int completedCount;

    private float movementSpeed;
    private float horizontalMovement;
    private float verticalMovement;
    
    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
        startParent = transform.parent;
        completedCount = 0;
        movementSpeed = 7.5f;
    }

    // Update is called once per frame
    void Update() {
        horizontalMovement = 0;
        verticalMovement = 0;
        
        if (Input.GetAxis("Horizontal") != 0)
            horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        if (Input.GetAxis("Vertical") != 0)
            verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate() {
        transform.position += new Vector3(horizontalMovement, verticalMovement, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag.Equals("Car")) {
            transform.position = startPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("EndPosition")) {
            ++completedCount;
            transform.parent = startParent;
            transform.position = startPosition;
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            if (completedCount == 5) {
                finishUI.SetActive(true);
            }
        }
        else if (other.tag.Equals("Platform")) {
            transform.position = other.gameObject.transform.position;
            transform.parent = other.gameObject.transform;
        }
        else if (other.tag.Equals("Water")) {
            transform.parent = startParent;
            transform.position = startPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag.Equals("Platform")) {
            transform.parent = other.gameObject.transform.parent;
        }
    }
}
