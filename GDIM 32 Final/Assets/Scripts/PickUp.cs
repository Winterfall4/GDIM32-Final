using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    //This adds an item and desapires them from the map 
    public void Pickup()
    {        
        bool add = InventoryManager.Instance.Add(Item);

        if (add)
        {
            Destroy(gameObject);
        }
       
    }

}

