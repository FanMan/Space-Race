using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controls : NetworkBehaviour
{
    float HorizontalTilt = 0;   // 
    float VerticalTilt = 0;     // 
    float FixedTime = 0;        // 
    Vector3 VerticalRot;
    Vector3 HorizontalRot;

    GameObject item;
    GameObject ItemPrefab;


    public Motion shipMotion;
    public GameObject ItemSpawnLoc;
    public GameObject Ship;
    private bool ItemExists;

    void Start()
    {
        VerticalRot = new Vector3(30, 0, 0);
        HorizontalRot = new Vector3(0, 60, 0);
        ItemExists = false;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        HorizontalTilt = Input.GetAxis("Horizontal");
        VerticalTilt = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Space))
        {
            shipMotion.ApplyMotion(true);
        }
        else
        {
            shipMotion.ApplyMotion(false);
        }

        shipMotion.ApplyTurn(HorizontalTilt * Vector3.up);
        shipMotion.ApplyRotation(VerticalTilt * Vector3.right);

        if(Input.GetKeyDown(KeyCode.Mouse0) && ItemExists)
        {
            print("Using item");
            //item = Instantiate(ItemPrefab, this.transform);
            //item.transform.position = this.transform.position;
            //ItemExists = false;
            item = Instantiate(ItemPrefab, ItemSpawnLoc.transform.position, this.transform.localRotation);
            //item.transform.position = ItemSpawnLoc.transform.position;
            ItemExists = false;
        }
        
    }
    
    public void GetItem(GameObject tempItem)
    {
        ItemPrefab = tempItem;
        ItemExists = true;
        print("Player has: " + ItemPrefab.ToString());
    }
    
}
