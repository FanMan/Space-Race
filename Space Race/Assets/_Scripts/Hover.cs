using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour 
{
	float originalPosY;
	public float hoverSpeed;

	void Start ()
	{
		this.originalPosY = this.transform.position.y;
	}

	void Update () 
	{
		//transform.Translate(Vector3.up * hoverSpeed * Time.deltaTime, Space.World);
		//yield return new WaitForSeconds (1);
		//transform.Translate(Vector3.down * hoverSpeed * Time.deltaTime, Space.World);
		transform.position = new Vector3 (transform.position.x, originalPosY + ((float)Mathf.Sin (Time.time) * hoverSpeed), transform.position.z);
	}
}
