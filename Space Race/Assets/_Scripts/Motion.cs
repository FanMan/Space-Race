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
    [SerializeField]
    private float BoostTime;        // duration of boost
    [SerializeField]
    private float DisableTime;      // how long the ship is disabled

    private float CurrentSpeed;     // the current speed of the ship
    private float FixedTime;

    private Vector3 HorizontalRot, VerticalRot;

    private bool ApplySpeed;        // tells whether to apply speed to the ship

	void Start () {
        CurrentSpeed = 0;
        HorizontalRot = Vector3.zero;
        VerticalRot = Vector3.zero;
    }

    void FixedUpdate()
    {
        if(!isLocalPlayer) { return; }

        FixedTime = Time.fixedDeltaTime;

        // apply speed to the spacecraft
        if(ApplySpeed)
        {
            //print("Applying speed: " + ApplySpeed);
            CurrentSpeed += Acceleration;
            
            // if the current speed goes over the max speed, set it equal to max speed
            if (CurrentSpeed > MaxSpeed)
            {
                CurrentSpeed = MaxSpeed;
            }
        }
        // apply deceleration to the spacecraft
        else
        {
            CurrentSpeed -= Acceleration;

            if(CurrentSpeed < 0)
            {
                CurrentSpeed = 0;
            }
        }
//        Debug.Log("Current Speed: " + CurrentSpeed);
        // applies the speed in the forward direction
        this.transform.Translate(Vector3.forward * CurrentSpeed * FixedTime);
        // applies left/right turning
        this.transform.RotateAround(this.transform.position, HorizontalRot, TurnSpeed * FixedTime);
        // applies upward/downward turning
        this.transform.Rotate(VerticalRot, TurnSpeed * FixedTime);
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

    public float GetDisableTime()
    {
        return DisableTime;
    }

    // Coroutines

    public IEnumerator StopShip()
    {
        //Debug.Log("StopShip Coroutine called");
        gameObject.GetComponent<Controls>().enabled = false;
        ApplySpeed = false;
        yield return new WaitForSeconds(DisableTime);
       // Debug.Log("Ship can start moving again");
        gameObject.GetComponent<Controls>().enabled = true;
    }

    public IEnumerator ActivateBoost()
    {
        // temporarily set the max speed to double
        MaxSpeed *= 2;
        // set the current speed to the max speed
        CurrentSpeed = MaxSpeed;
       // Debug.Log("Boost Applied");

        yield return new WaitForSeconds(BoostTime);

       // Debug.Log("Boost Ended");
        // Set MaxSpeed back to normal
        MaxSpeed = (MaxSpeed / 2);
        CurrentSpeed = MaxSpeed;
    }
}
