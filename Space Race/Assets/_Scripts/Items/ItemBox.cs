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
        }
    }

    public GameObject getItem()
    {
        return CurrentItem;
    }

    void DisableItem(bool active)
    {
        CurrentItem.SetActive(active);
    }

    void Visual()
    {
        // rotate the item box around its self on the y-axis
        this.transform.RotateAround(this.transform.position, Vector3.up, dt * TurnSpeed);
    }
}
