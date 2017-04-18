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
        //this.transform.rotation = Quaternion.Euler(90, 0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ActivateRocket();
	}
    
    public void ActivateRocket()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * RocketSpeed * Time.fixedDeltaTime);
    }
    
    void OnCollisionEnter(Collision Object)
    {
        if(Object.gameObject.CompareTag("Player"))
        {
            // player.stopMovement()
            Destroy(Rockets);
            // play explosion
        }
        else
        {
            Destroy(Rockets);
            // play explosion
        }
    }
}
