using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{

	
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.L))
        {
            print("Throwing EMP bomb");

        }
	}

    // if a ship enters the explosion radius
    // will work on this later
    void OnTriggerEnter(Collider ShipObject)
    {
        if(ShipObject.CompareTag("Player"))
        {
            // stop the ship momentarily

        }
    }
}
