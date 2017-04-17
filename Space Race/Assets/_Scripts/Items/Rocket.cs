using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float RocketSpeed;
    [SerializeField]
    private GameObject Rockets;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ActivateRocket();
	}
    
    public void ActivateRocket()
    {
        
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
