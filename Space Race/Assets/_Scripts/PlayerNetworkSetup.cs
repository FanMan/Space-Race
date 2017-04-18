using UnityEngine;
using UnityEngine.Networking;


public class PlayerNetworkSetup : NetworkBehaviour 
{
	[SerializeField]
	Behaviour [] toBeDisabled;
	Camera offlineCam;

	void Start () 
	{
		if (!isLocalPlayer)
		{
			for (int i=0; i<toBeDisabled.Length; i++)
			{
				toBeDisabled[i].enabled = false;
			}
		}	
		else
		{
			offlineCam = Camera.main;
			if (offlineCam != null)
				offlineCam.gameObject.SetActive(false);
		}

	}
	
	void OnDisable()
	{
		if (offlineCam != null)
		{
			offlineCam.gameObject.SetActive(true);
		}
	}



	public override void OnStartLocalPlayer ()
	{
		//base.OnStartLocalPlayer ();

		if (isLocalPlayer)
		{
			GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
		}
	}

}
