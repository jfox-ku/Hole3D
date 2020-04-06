using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript instance;

    public Camera mainCam;
    public MoveController player;
    public int level = 0;
    public Text ScoreText;
    public Text TimeText;
    public Text EndGameText;
    private int[] levelBoxNum;
    private int currentLevelScore;
    public GameObject[] ArenaHolders;
    public GameObject[] Doors;
    public Light lit;
    private Color[] clrs;
    //private float runTime;

    private void Awake() {
        
        init();
        level = 0;
        //runTime = Time.time;
        //runTime = 0;
        currentLevelScore = 0;
        levelBoxNum = new int[3] { 256, 224, 400 };
        clrs = new Color[4] { Color.red, Color.blue, Color.cyan, Color.magenta };
        
    }

    private void init() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
    }

	// Update is called once per frame
	void Update () {
        //if(runTime != null) {
        //    runTime = Time.time;
        //    TimeText.text = "Time2: " + runTime;
        //}  
	}



    public void ScoreCalc(GameObject fallenObject) {
        if(fallenObject.tag == "box") {
            currentLevelScore++;
            ScoreText.text = (levelBoxNum[level] - currentLevelScore) + " left!";
        }

        if (checkLevelDone()) {
            procede();
        }

    }


    public void gameReset() {
       // Debug.Log("Game reset called.");
        SceneManager.LoadSceneAsync("mainScene");

    }

    public bool checkLevelDone() {
        if ((levelBoxNum[level] - currentLevelScore) == 0) {
            //Debug.Log("Level Check returned true");
            return true;
        } else {
            return false;
        }
    }

    public void procede() {
        //Debug.Log("Procede called!");
        if (level < levelBoxNum.Length-1) {
            raiseTheGates();
            moveTheCamera();
        }
        level++;
        if(level == levelBoxNum.Length) {
            endGame();
        } else {
            player.moveToNextLevel();
            currentLevelScore = 0;
           // Debug.Log("Spawning next level: " + level);
            ArenaHolders[level].SetActive(true);
            ScoreText.text = "" + (levelBoxNum[level] - currentLevelScore) + " left!";

            lit.color = clrs[Random.Range(0, clrs.Length)];
        }   
    }

    private void raiseTheGates() {
        GameObject Door = Doors[level];
        float y = Door.transform.position.y + 2.5f;
        Vector3 newPos = new Vector3(Door.transform.position.x, y, Door.transform.position.z);
        //Doors[level].transform.SetPositionAndRotation(Doors[level].transform.position + new Vector3(0,5,0), new Quaternion());
        Door.transform.position = newPos;
    }

    private void moveTheCamera() {
        float z = mainCam.transform.position.z + 33f;
        Vector3 newPos = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y,z);
        mainCam.transform.position = newPos;
    }

    private void endGame() {
        EndGameText.gameObject.SetActive(true);
    }


}
