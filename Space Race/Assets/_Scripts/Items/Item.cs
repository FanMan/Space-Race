using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Vector3 ItemPos;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void SpawnItem(Vector3 PlayerPos)
    {
        ItemPos = PlayerPos;
    }
}
