using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField]
    private float Acceleration;
    [SerializeField]
    private float TurnSpeed;
    private float CurrentSpeed;
    private float MaxSpeed;
    private float FixedTime;

    private bool ApplySpeed, ApplyBoost;

	void Start () {
        CurrentSpeed = 0;
        MaxSpeed = 30;
	}
	
    void Update()
    {
        FixedTime = Time.deltaTime;

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

        this.transform.Translate(Vector3.forward * CurrentSpeed * FixedTime);
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

    public void ApplyTurn()
    {

    }

    public void ApplyRotation()
    {

    }
}
