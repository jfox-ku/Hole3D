using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    private int level = 0;
    private int[,] lvlBounds;
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
        

    }
	
	// Update is called once per frame
	void Update () {

        if(this.transform.position.z < bottomZ) {
            this.transform.SetPositionAndRotation(new Vector3(oldPos.x, oldPos.y, bottomZ), new Quaternion());
        } else {
            if (Input.GetKey("w")) {
                Vector3 nextPos = oldPos + new Vector3(0, 0, step);
                if(boundCheck(nextPos))
                    this.transform.SetPositionAndRotation(nextPos, new Quaternion());

            }

            if (Input.GetKey("s")) {
                Vector3 nextPos = oldPos + new Vector3(0, 0, -step);
                if (boundCheck(nextPos))
                    this.transform.SetPositionAndRotation(nextPos, new Quaternion());

            }

            if (Input.GetKey("a")) {
                Vector3 nextPos = oldPos + new Vector3(-step, 0, 0);
                if (boundCheck(nextPos))
                    this.transform.SetPositionAndRotation(nextPos, new Quaternion());
            }

            if (Input.GetKey("d")) {
                Vector3 nextPos = oldPos + new Vector3(step, 0, 0);
                if (boundCheck(nextPos))
                    this.transform.SetPositionAndRotation(nextPos, new Quaternion());        
            }
        }

       



        oldPos = this.transform.position;
    }


    private bool boundCheck(Vector3 pos) {
        if (pos.x < lvlBounds[level, 0] || pos.x > lvlBounds[level, 1]) return false;
        if (pos.z < lvlBounds[level,2] || pos.z>lvlBounds[level,3]) return false;
        return true;
    }

    public void moveToNextLevel() {
        this.transform.position = new Vector3(-2.2f, 0.01f, 46.68f);
        level = gcs.level;
    }


}
