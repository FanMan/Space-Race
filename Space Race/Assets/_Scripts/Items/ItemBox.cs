using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField]
    private float TurnSpeed;
    [SerializeField]
    private float DisableTime;
    [SerializeField]
    private List<GameObject> Items;
    private GameObject CurrentItem = null;
    private float dt;

    void Update()
    {
        dt = Time.deltaTime;
        Visual();
    }

    void OnTriggerEnter(Collider ShipObject)
    {
        // 
        if (ShipObject.CompareTag("Player"))
        {
            print("Player gets item");
            CurrentItem = Items[Random.Range(0, Items.Count)];
            // need to create a public method in the player called RecievedItem
            ShipObject.GameObject.SendMessage("RecievedItem", CurrentItem);
        }
    }

    public GameObject getItem()
    {
        return CurrentItem;
    }

    void DisableItem(bool active)
    {
        // Disable the Mesh and Trigger only
       this.BoxCollider.enabled = false;
       this.MeshRenderer.enabled = false;
        //CurrentItem.SetActive(active);
    }

    void Visual()
    {
        // rotate the item box around its self on the y-axis
        this.transform.RotateAround(this.transform.position, Vector3.up, dt * TurnSpeed);
    }
}
