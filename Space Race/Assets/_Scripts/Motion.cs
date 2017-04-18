using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Motion : NetworkBehaviour
{
    [SerializeField]
    private float Acceleration;     // how fast the ship speeds up
    [SerializeField]
    private float TurnSpeed;        // how quickly the ship rotates
    [SerializeField]
    private float MaxSpeed;         // the maximum speed the ship can go

    private float CurrentSpeed;     // the current speed of the ship
    private float FixedTime;

    private Vector3 HorizontalRot, VerticalRot;

    private bool ApplySpeed, ApplyBoost;

	void Start () {
        CurrentSpeed = 0;
        MaxSpeed = 30;
        HorizontalRot = Vector3.zero;
        VerticalRot = Vector3.zero;
	}
	
    void FixedUpdate()
    {
        if(!isLocalPlayer) { return; }

        FixedTime = Time.fixedDeltaTime;

        if(ApplySpeed)
        {
            //print("Applying speed: " + ApplySpeed);
            CurrentSpeed += Acceleration;
            //print("Current Speed: " + CurrentSpeed);
            if (CurrentSpeed > MaxSpeed)
            {
                CurrentSpeed = MaxSpeed;
            }
        }
        else
        {
            CurrentSpeed -= Acceleration;

            if(CurrentSpeed < 0)
            {
                CurrentSpeed = 0;
            }
        }

        // applies the speed in the forward direction
        this.transform.Translate(Vector3.forward * CurrentSpeed * FixedTime);
        // applies left/right turning
        this.transform.RotateAround(this.transform.position, HorizontalRot, TurnSpeed * FixedTime);
        // applies upward/downward turning
        this.transform.Rotate(VerticalRot, TurnSpeed * FixedTime);
    }

    void TurningControls()
    {
        // if no input from both vertical and horizontal input for a second
        // level the ship to face forward
        // else apply motion
    }

    public void ApplyMotion(bool move)
    {
        ApplySpeed = move;
    }

    public void ApplyTurn(Vector3 Horizontal)
    {
        HorizontalRot = Horizontal;
    }

    public void ApplyRotation(Vector3 Vertical)
    {
        VerticalRot = Vertical;
    }

    public void StopShip()
    {
        CurrentSpeed = 0;
    }
}
