using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EMP : NetworkBehaviour
{
    [SerializeField]
    private float ActivationTime;
    [SerializeField]
    private float ExplosionDuration;
    private float timeTillDetonate;
    private float timeTillDestroyed;

    private GameObject EMPGrenade;

	void Start ()
    {
        timeTillDetonate = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeTillDetonate += Time.deltaTime;

        if(timeTillDetonate > ActivationTime)
        {
            // activate explosion
        }
	}

    // if a ship enters the explosion radius
    // will work on this later
    void OnTriggerEnter(Collider ShipObject)
    {
        if(ShipObject.CompareTag("Player"))
        {
            // stop the ship momentarily
            ShipObject.GetComponent<Motion>().StopShip();
        }
    }
    
    public void ActivateExplosion()
    {
        
    }
}
