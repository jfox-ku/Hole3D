using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	private float speed = 3f;
    private Rigidbody rgb;
	
	// Use this for initialization
	void Start () {

        rgb = GetComponent<Rigidbody>();
        rgb.velocity = new Vector3(0,0,0);

	}
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKey("w")) {
           // Debug.Log("W pressed");
            rgb.velocity = new Vector3(0, 0, speed);
        }
            
        else if (Input.GetKey("s")) {
            rgb.velocity = new Vector3(0, 0, -speed);
        } else if (Input.GetKey("d")) {
            rgb.velocity = new Vector3(speed, 0, 0);
        } else if (Input.GetKey("a")) {
            rgb.velocity = new Vector3(-speed, 0, 0);
        }

    }



    private void OnCollisionEnter(Collision collision) {
            Debug.Log("Collision test");
        if (collision.gameObject.tag == "Boxes") {
            Debug.Log("Box Collision test");
            
        }
            

    }
}
