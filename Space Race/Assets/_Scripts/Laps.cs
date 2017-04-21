using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Laps : NetworkBehaviour 
{
	//for ships

	public static int currentCheckpoint = 0; 	//what checkpoint we are currently on
	public static int currentLap = 0; 			//what lap we are currently on
	public int Lap;								//ship's lap count
	public Transform[] checkPointArray;			//keeps track of which checkpoint the player has passed/is going to pass
	public static Transform[] checkpointA;		//stores the checkpoint
	public Vector3 initPos;						//ship's starting position
    public GameObject TextDesc;
    public GameObject TimeDesc;
    public GameObject FinishDesc;

    private Text LapText, TimeText, FinishText;
    private float TrackRaceTime;
    private float Minute, Second;

	void  Start ()
	{
		if (!isLocalPlayer)
			return;

		//initial position of the ship when we start
		initPos = transform.position;
		//set these to 0 - this is where we start from the git-go
		currentCheckpoint = 0;
		currentLap = 0;

        LapText = TextDesc.GetComponentInChildren<Text>();
        LapText.text = "Lap: " + Lap + "/3";

        TimeText = TimeDesc.GetComponentInChildren<Text>();
        TimeText.enabled = false;

        FinishText = FinishDesc.GetComponentInChildren<Text>();
        FinishText.enabled = false;
	}

	void  Update ()
	{
		Lap = currentLap;
		checkpointA = checkPointArray;

        // once the player goes through the checkpoint, start the timer
        if (Lap > 0 && Lap < 4)
        {
            TrackRaceTime += Time.deltaTime;
        }

        //if they completed 3 laps, go to the next map
        if (Lap > 3) 
		{
            /* http://answers.unity3d.com/questions/200733/timetime-as-minutes-and-seconds-.html */
            Minute = Mathf.Round(TrackRaceTime / 60);
            Second = Mathf.Round(TrackRaceTime % 60);

            TimeText.text = "Time: " + Minute + ":" + Second;
            TimeText.enabled = true;

            FinishText.text = "Finished";
            FinishText.enabled = true;

            // disable ship motion once the player crosses the finish line
            GetComponent<Motion>().enabled = false;

            //SceneManager.LoadScene(1);
        }
        
        UpdateLapGui();
	}

    public void UpdateLapGui()
    {
        switch(Lap)
        {
            case 0:
                LapText.text = "Lap: " + Lap + "/3";
                break;
            case 1:
                LapText.text = "Lap: " + Lap + "/3";
                break;
            case 2:
                LapText.text = "Lap: " + Lap + "/3";
                break;
            case 3:
                LapText.text = "Lap: " + Lap + "/3";
                break;
        }
    }
}