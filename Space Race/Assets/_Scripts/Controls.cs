using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    float HorizontalTilt = 0;
    float VerticalTilt = 0;
    float FixedTime = 0;
    Vector3 VerticalRot;
    Vector3 HorizontalRot;

    void Start()
    {
        VerticalRot = new Vector3(30, 0, 0);
        HorizontalRot = new Vector3(0, 60, -30);
    }

    void FixedUpdate()
    {
        FixedTime = Time.fixedDeltaTime;

        HorizontalTilt = Input.GetAxis("Horizontal");
        VerticalTilt = Input.GetAxis("Vertical");

        // Upwards and Downwards direction
        if (VerticalTilt > 0)
        {
            this.transform.Rotate(VerticalRot * FixedTime);
        }
        else if (VerticalTilt < 0)
        {
            this.transform.Rotate(-VerticalRot * FixedTime);
        }

        // Left and Right movement
        if (HorizontalTilt > 0)
        {
            this.transform.Rotate(HorizontalRot * FixedTime);
        }
        else if (HorizontalTilt < 0)
        {
            this.transform.Rotate(-HorizontalRot * FixedTime);
        }

        // used to move the rocket forward
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Translate(Vector3.forward * 20 * FixedTime);
        }
    }
}
