using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Controls : NetworkBehaviour
{
    public Motion shipMotion;
    public GameObject ItemSpawnLoc; // location where the items will spawn
    public GameObject TextItemName;
    public GameObject TextItemDesc;

    private float HorizontalTilt = 0;   // 
    private float VerticalTilt = 0;     // 
    private float FixedTime = 0;        // 
    private bool ItemExists;            // says whether the item exists on the spacecraft

    private Vector3 VerticalRot;
    private Vector3 HorizontalRot;
    private GameObject item;            // stores the actual game object for use/spawning
    private GameObject ItemPrefab;      // prefab used to store the item recieved from the itembox
    private Text ItemDesc, ItemName;
    
    void Start()
    {
        VerticalRot = new Vector3(30, 0, 0);
        HorizontalRot = new Vector3(0, 60, 0);
        ItemExists = false;
        ItemDesc = TextItemDesc.GetComponentInChildren<Text>();
        ItemName = TextItemName.GetComponentInChildren<Text>();
        ItemName.text = "Item";
        ItemDesc.text = "None";
        
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

        // spawn item on the server if the player has it
        if(Input.GetKeyDown(KeyCode.Mouse0) && ItemExists)
        {
            CmdUseItem();
            ItemExists = false;
        }
        
    }
    
    // 
    public void GetItem(GameObject tempItem)
    {
        // if no item exists currently
        if (!ItemExists)
        {
            ItemPrefab = tempItem;
            ItemName.text = GetItemName(ItemPrefab);
            ItemDesc.text = GetItemDescription(ItemPrefab);
            ItemExists = true;
            print("Player has: " + ItemPrefab.ToString());
        }
    }

    // used to spawn the item on the server
    [Command]
    public void CmdUseItem()
    {
        print("Using item");

        // special use case for speed boost
        if (ItemPrefab.transform.name.ToString().Equals("SpeedBoost"))
        {
            StartCoroutine(GetComponent<Motion>().ActivateBoost());
        }
        // special use case for shield
        else if (ItemPrefab.transform.name.ToString().Equals("Shield"))
        {
            // make it the child of the spacecraft in the hierarchy
            item = Instantiate(ItemPrefab, this.transform);
            // apply the position where the spacecraft is
            item.transform.position = transform.position;
        }
        else
        {
            item = Instantiate(ItemPrefab, ItemSpawnLoc.transform.position, this.transform.rotation);
        }

        // reset the item info to null as nothing is there
        ItemName.text = "Item";
        ItemDesc.text = "None";

        NetworkServer.Spawn(item);
    }

    string GetItemName(GameObject prefab)
    {
        if (prefab.transform.name.ToString().Equals("EMP"))
            return "EMP Grenade";
        else if (prefab.transform.name.ToString().Equals("Shield"))
            return "Shield";
        else if (prefab.transform.name.ToString().Equals("Rocket"))
            return "Rocket";
        else if (prefab.transform.name.ToString().Equals("SpeedBoost"))
            return "Rocket Boost";
        else
            return "No item";
    }

    string GetItemDescription(GameObject prefab)
    {
        if (prefab.transform.name.ToString().Equals("EMP"))
            return "On use, disable any ship caught in blast for " + GetComponent<Motion>().GetDisableTime() + " seconds";
        else if (prefab.transform.name.ToString().Equals("Shield"))
            return "On use, blocks any items from hitting you for 7 seconds";
        else if (prefab.transform.name.ToString().Equals("Rocket"))
            return "On use, shoot a rocket. Disables ship for " + GetComponent<Motion>().GetDisableTime() + " seconds on hit";
        else if (prefab.transform.name.ToString().Equals("SpeedBoost"))
            return "On use, go twice the speed";
        else
            return "No item";
    }

    public void ItemInUse(bool exist)
    {
        ItemExists = exist;
    }
}
