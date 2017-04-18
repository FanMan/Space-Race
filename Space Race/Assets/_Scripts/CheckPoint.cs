using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour 
{
	//for checkpoints
	//public Transform[] checkPointArray;			//keeps track of which checkpoint the player has passed/is going to pass
	//public static Transform[] checkpointA;		//stores the checkpoint

	void  OnTriggerEnter (Collider other)
	{
		//checks if we are dealing with the player
		if (!other.CompareTag("Player")) 
			return; //if not get out of here
		//check if we hit one of the checkpoints in the array
		if (transform == Laps.checkpointA[Laps.currentCheckpoint].transform) 
		{
			//check to make sure we didnt go over how many checkpoints we set
			if (Laps.currentCheckpoint + 1 < Laps.checkpointA.Length) 
			{
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


	}

}