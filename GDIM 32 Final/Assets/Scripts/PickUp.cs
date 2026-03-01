using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    
    //This adds an item and desapires them from the map 
    public void Pickup()
    {        
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

}

