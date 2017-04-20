using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CheckPoint : NetworkBehaviour 
{
	//for checkpoints
	//public Transform[] checkPointArray;
	//keeps track of which checkpoint the player has passed/is going to pass
	//public static Transform[] checkpointA;
	//stores the checkpoint

	void  OnTriggerEnter (Collider other)
	{
		Debug.Log ("Object that passed: " + other.transform.name);
		//checks if we are dealing with the player
		if (!other.CompareTag("Player"))
		{
			Debug.Log ("Not the player");
			return; //if not get out of here
		}

		if (Laps.currentCheckpoint + 1 < Laps.checkpointA.Length + 1) 
		{
			if (Laps.currentCheckpoint == 0) 
			{
				Laps.currentLap++;
				Debug.Log ("Lap incremented");
				//Laps.currentCheckpoint = 0;
				//Debug.Log ("Checkpoint reset to 0");

			}
			Laps.currentCheckpoint++;
			Debug.Log ("Current Checkpoint: " + Laps.currentCheckpoint);

		} else if (Laps.currentCheckpoint + 1 > Laps.checkpointA.Length)
			Laps.currentCheckpoint = 0;
		else
			Laps.currentCheckpoint = 0;
		//Laps.currentLap++;

/*
if (Laps.currentCheckpoint + 1 > Laps.checkpointA.Length) 
{
Laps.currentCheckpoint = 0;
Debug.Log ("Checkpoint reset to 0");
}
*/

		Debug.Log ("aisdjhkad");

		/*
		//check if we hit one of the checkpoints in the array
		if (transform == Laps.checkpointA[Laps.currentCheckpoint].transform) 
		{
			Debug.Log ("Player went through a checkpoint");
			//check to make sure we didnt go over how many checkpoints we set
			if (Laps.currentCheckpoint + 1 < Laps.checkpointA.Length) 
			{
				Debug.Log ("Player went through checkpoint " + Laps.currentCheckpoint);
				//increment lap as player went through all checkpoints - yay
				if(Laps.currentCheckpoint == 0)
					Laps.currentLap++;
				Laps.currentCheckpoint++;
			} 
			else 
			{
				//If we dont have any checkpoints left, reset to 0 so it can increment again
				Laps.currentCheckpoint = 0;
			}
		}
		*/


	}

}