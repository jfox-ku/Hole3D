﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    private int level;
    private int[,] lvlBounds;
    private int[,] lvlSpawnPos;
    
    private float bottomZ = 10;

    public GameControllerScript gcs;


    Transform pos;
    Vector3 oldPos;
    public float step = 0.5f;

	// Use this for initialization
	void Start () {
        level = gcs.level;
        oldPos = this.transform.position;
        
        // {xleftBound, xRightBound, zBottomBound, zUpperBound}
        lvlBounds = new int[3, 4] { {-13, 8, 10, 32}, { -13, 8, 46, 68}, { -13, 8, 82, 104}};
        // {x,z} since y is fixed
        lvlSpawnPos = new int[3, 2] { {-2,13}, { -2, 47 }, { -2, 81 }};
        this.transform.position = new Vector3(lvlSpawnPos[level,0],0.1f, lvlSpawnPos[level, 1]);
        

    }

    // Update is called once per frame
    private void Update() {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        oldPos = this.transform.position;
        Debug.Log("X:"+MouseX+", Y:"+MouseY);
        this.transform.position = new Vector3(oldPos.x + (MouseX * step), oldPos.y, oldPos.z + (MouseY * step));
    }

    //void Update () {

    //       if(this.transform.position.z < bottomZ) {
    //           this.transform.SetPositionAndRotation(new Vector3(oldPos.x, oldPos.y, bottomZ), new Quaternion());
    //       } else {
    //           if (Input.GetKey("w")) {
    //               Vector3 nextPos = oldPos + new Vector3(0, 0, step);
    //               if(boundCheck(nextPos))
    //                   this.transform.SetPositionAndRotation(nextPos, new Quaternion());

    //           }

    //           if (Input.GetKey("s")) {
    //               Vector3 nextPos = oldPos + new Vector3(0, 0, -step);
    //               if (boundCheck(nextPos))
    //                   this.transform.SetPositionAndRotation(nextPos, new Quaternion());

    //           }

    //           if (Input.GetKey("a")) {
    //               Vector3 nextPos = oldPos + new Vector3(-step, 0, 0);
    //               if (boundCheck(nextPos))
    //                   this.transform.SetPositionAndRotation(nextPos, new Quaternion());
    //           }

    //           if (Input.GetKey("d")) {
    //               Vector3 nextPos = oldPos + new Vector3(step, 0, 0);
    //               if (boundCheck(nextPos))
    //                   this.transform.SetPositionAndRotation(nextPos, new Quaternion());        
    //           }
    //       }





    //       oldPos = this.transform.position;
    //   }

    private Vector3 dragStartPos;
    


    private bool boundCheck(Vector3 pos) {
        if (pos.x < lvlBounds[level, 0] || pos.x > lvlBounds[level, 1]) return false;
        if (pos.z < lvlBounds[level,2] || pos.z>lvlBounds[level,3]) return false;
        return true;
    }

    public void moveToNextLevel() {
        Vector3 oldPos = this.transform.position;
        
        level = gcs.level;
        this.transform.position = new Vector3(lvlSpawnPos[level, 0], 0.1f, lvlSpawnPos[level, 1]);
    }


}
