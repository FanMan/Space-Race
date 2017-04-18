using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

	public GameObject[]  Ships;
	GameObject ShipModel;

	void Start () {
		ShipModel = Instantiate(Ships[Random.Range(0, Ships.Length)], this.transform);
		this.GetComponent<BoxCollider> ().size = ShipModel.transform.localScale;
	}

	/*
	void Update () {
		
	}*/
}
