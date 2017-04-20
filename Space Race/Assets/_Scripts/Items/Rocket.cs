using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Rocket : NetworkBehaviour
{
    [SerializeField]
    private float RocketSpeed;
    [SerializeField]
    private GameObject Rockets;

	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ActivateRocket();
	}
    
    public void ActivateRocket()
    {
        this.transform.Translate(Vector3.forward * RocketSpeed * Time.fixedDeltaTime);
    }
    
    void OnCollisionEnter(Collision ShipObject)
    {
        if(ShipObject.gameObject.CompareTag("Player"))
        {
            // player.stopMovement()
            Debug.Log("Player was attacked");
            StartCoroutine(ShipObject.gameObject.GetComponent<Motion>().StopShip());
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            Destroy(Rockets, 10);
        }
        else
        {
            Debug.Log("Rocket crashed into wall");
            Destroy(Rockets);
            // play explosion
        }
    }
}
