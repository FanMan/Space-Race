using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private float Duration;
    private float CurrentTime;
    private bool objectCollision;
    [SerializeField]
    private GameObject SheildObject;

    void Start()
    {
        CurrentTime = 0;
        objectCollision = false;
    }

    void Update()
    {
        
    }

    public void SpawnShield(Vector3 ShipPosition)
    {
        SheildObject.transform.position = ShipPosition;

        CurrentTime += Time.deltaTime;
        /*
        if (CurrentTime >= Duration && !objectCollision)
        {
            DestroyObject(this, 0);
            print("Object has been destroyed");
            // play dissapate explosion
        }*/
    }

    void OnTriggerEnter(Collider ItemObject)
    {
        if (ItemObject.CompareTag("Item") && !objectCollision)
        {
            DestroyObject(ItemObject, 0);
            DestroyObject(this, 0);
            objectCollision = true;
            // play explosion
        }
    }


}
