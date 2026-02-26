using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    
    //This adds an item and desapires them from the map 
    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    //Detect the mouse click

    private void OnMouseDown()
    {
        Pickup();
    }


}

