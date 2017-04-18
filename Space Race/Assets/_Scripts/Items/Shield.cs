using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shield : NetworkBehaviour
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
        ActivateShield();
    }

    // activate upon creation
    public void ActivateShield()
    {
        CurrentTime += Time.deltaTime;
        
        if (CurrentTime >= Duration && !objectCollision)
        {
            Destroy(SheildObject);
            print("Shield has been destroyed");
            // play dissapate explosion
        }
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
