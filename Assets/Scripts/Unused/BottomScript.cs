using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomScript : MonoBehaviour {

    public GameObject GameController;
    private GameControllerScript controller;
    // Use this for initialization
    void Start () {
         controller = GameController.GetComponent<GameControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "box") {
            controller.ScoreCalc(other.gameObject);
            //Debug.Log("Destroy Called");
            Destroy(other.gameObject);
        }else if(other.gameObject.tag == "failBox") {
            controller.gameReset();
        }
    }

}
