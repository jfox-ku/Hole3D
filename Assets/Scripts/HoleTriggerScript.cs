using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other) {
        //Debug.Log("Force done");
        Rigidbody rgb = other.gameObject.GetComponent<Rigidbody>();
        rgb.AddForce(new Vector3(0, -0.5f, 0), ForceMode.Impulse);
    }
}
