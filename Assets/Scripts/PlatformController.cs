using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    private float speed;
    
    // Start is called before the first frame update
    void Start() {
        if (transform.position.x < 0) speed = 1.5f;
        else speed = -2.4f;
    }

    // Update is called once per frame
    void Update() {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if(transform.position.x > 12 || transform.position.x < -12) Destroy(gameObject);
    }
}