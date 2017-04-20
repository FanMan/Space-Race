using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EMP : NetworkBehaviour
{
    [SerializeField]
    private GameObject EMPGrenade;
    [SerializeField]
    private float ActivationTime;       // time to wait until the explosion
    [SerializeField]
    private float ExplosionDuration;    // how long the explosion lasts
    [SerializeField]
    private float ExplosionSize;        // how large the explosion is
    private float timeTillDetonate;
    private float timeTillDestroyed;

    void Start()
    {
        timeTillDetonate = 0;
        timeTillDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeTillDetonate += Time.deltaTime;

        if (timeTillDetonate > ActivationTime)
        {
            timeTillDestroyed += Time.deltaTime;
            // activate explosion
            ActivateExplosion();

            if (timeTillDestroyed > ExplosionDuration)
            {
                EMPGrenade.GetComponent<MeshRenderer>().enabled = false;
                EMPGrenade.GetComponent<SphereCollider>().enabled = false;
                Destroy(EMPGrenade, 10);
            }
        }
    }

    // if a ship enters the explosion radius, stop the ship for a few seconds
    void OnTriggerEnter(Collider ShipObject)
    {
        if (ShipObject.CompareTag("Player"))
        {
            // stop the ship momentarily
            Debug.Log("Ship slowed down");
            StartCoroutine(ShipObject.GetComponent<Motion>().StopShip());
        }
    }

    public void ActivateExplosion()
    {
        if (ExplosionSize > transform.localScale.y)
        {
            transform.localScale += new Vector3(ExplosionSize * Time.deltaTime, 
            ExplosionSize * Time.deltaTime, ExplosionSize * Time.deltaTime);
        }
    }
}
