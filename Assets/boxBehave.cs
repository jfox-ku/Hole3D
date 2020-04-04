using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBehave : MonoBehaviour {

    private string CollMode = "all";
    private Renderer render;
    private Collider boxCol;
    public Collider grndCol;

    // Use this for initialization
    void Start() {
        render = GetComponent<Renderer>();
       
        boxCol = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {


    }

    private void OnCollisionStay(Collision collision) {
        Debug.Log("Collision staying");

        if (CollMode == "all") {


        } else if (CollMode == "boxesOnly") {
            if (collision.gameObject.tag == "Ground") {
                Debug.Log("Ignored");
                Physics.IgnoreCollision(grndCol, boxCol);
            }

        }


    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Hole") {
            render.material.color = Color.cyan;
            CollMode = "boxesOnly";
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Hole") {
            render.material.color = Color.red;
            CollMode = "all";
        }
    }

}


