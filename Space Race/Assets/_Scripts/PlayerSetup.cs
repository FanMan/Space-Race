using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] toBeDisabled;
    Camera offlineCam;

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
	void Update () {
		
	}

    void OnDisable()
    {
        if (offlineCam != null)
        {
            offlineCam.gameObject.SetActive(true);
        }
    }
}
