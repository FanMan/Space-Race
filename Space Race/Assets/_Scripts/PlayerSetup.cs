using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] toBeDisabled;
    Camera offlineCam;
	public static List<GameObject> ships;			//a list of players' ships
	//public static List<GameObject> shipStatus;

	//public static List<SyncListBool> shipStatus;	//a list of booleans that will be synced from server to clients 

	//public static GameObject[] ships;
	//public static GameObject[] shipStatus;

    void Start () {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < toBeDisabled.Length; i++)
            {
                toBeDisabled[i].enabled = false;
            }
        }
        else
        {
            offlineCam = Camera.main;
            if (offlineCam != null)
            {
                offlineCam.gameObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//the given prefab will be instanted on all clients in the game
	//https://docs.unity3d.com/ScriptReference/Network.Instantiate.html
	void OnNetworkInstantiate(NetworkMessageInfo info) 
	{
		//if we are in the server, add our gameobject to the list
		if (Network.isServer) 
		{
			//creates a list of all ships entered on the sever
			ships.Add (gameObject);

			//maintains a list of the ships
			//shipStatus.Add(ships);

			//combined the above into one line?
			//shipStatus.Add(ships.Add(gameObject));

			//copies/references the players' ships to a boolean list
			//ships.CopyTo(shipStatus);

		}
	}

    void OnDisable()
    {
        if (offlineCam != null)
        {
            offlineCam.gameObject.SetActive(true);
        }
    }
}
