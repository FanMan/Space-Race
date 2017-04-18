using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Laps : MonoBehaviour 
{
	//for ships

	public static int currentCheckpoint = 0; 	//what checkpoint we are currently on
	public static int currentLap = 0; 			//what lap we are currently on
	public int Lap;								//ship's lap count
	public GameObject[] checkPointArray;		//keeps track of which checkpoint the player has passed/is going to pass
	public static GameObject[] checkpointA;		//stores the checkpoint
	public Vector3 initPos;						//ship's starting position

	void  Start ()
	{
		//initial position of the ship when we start
		initPos = transform.position;
		//set these to 0 - this is where we start from the git-go
		currentCheckpoint = 0;
		currentLap = 0; 

	}

	void  Update ()
	{
		Lap = currentLap;
		checkpointA = checkPointArray;

		//if they completed 3 laps, go to the next map
		if (Lap > 3) 
		{
			SceneManager.LoadScene(1);
		}
	}

}