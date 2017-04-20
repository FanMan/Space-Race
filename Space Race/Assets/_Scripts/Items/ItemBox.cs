using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemBox : NetworkBehaviour
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
            ShipObject.gameObject.SendMessage("GetItem", CurrentItem);
            StartCoroutine(DisableItem());
        }
    }

    public IEnumerator DisableItem()
    {
        // Disable the Mesh and Trigger only when the player passes through it
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(DisableTime);

        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    void Visual()
    {
        // rotate the item box around its self on the y-axis
        this.transform.RotateAround(this.transform.position, Vector3.up, dt * TurnSpeed);
    }
}
