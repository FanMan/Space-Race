using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

	void OnTriggerEnter(Collider ShipObject)
    {
        if(ShipObject.CompareTag("Player"))
        {
            // increment the lap number
        }
    }
}
