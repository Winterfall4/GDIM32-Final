using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InventoryManager : MonoBehaviour
{
    //Singlenton Class
    public static InventoryManager Instance;
    //The list were are items stores
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public int Max = 5; 
    public GameObject InventaryMessage;



    //private void Start()
    //{
    //  Debug.Log("InventoryManager está activo");
    //}

    //This is the singleton, which ensures that there is only one inventory and no more.
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }


    public bool Add(Item item)
    {
        if (Items.Count >= Max)
        {
            InventaryMessage.SetActive(true);
            return false;
        }
        //PickUp items are here
        Items.Add(item);

        FlowBouquet(item);
        //This calls the list to update UI 
        ListItem();
        //InventaryMessage.SetActive(false);
        return true;
    }

    //Removes a item from list(this is for the remove option)(I work on this later)
    public void Remove(Item item)
    {
        Items.Remove(item);
    }


    public void ListItem()
    {
        //Debug.Log("ListItem se está ejecutando");
        
        // This avoid to have duplicate items when we only click 1 of them
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        //This creates the new cube items of UI acording to the list of items
        foreach (var item in Items)
        {
            //This creates the prefab child for "Content"
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            //Find and apply object information (Image/icon and name)
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("Item_Icon").GetComponent<Image>();

            //This makes the image and name visible on the screen.
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }
    
    //metod of drop
    public void DropItem(Transform playerTransform)
    {
        if (Items.Count <= 0)
            return;
        //This drops the last item of the list 
        Item itemDrop = Items[Items.Count - 1];

        //This Spawns the item in front of player
        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * 2f;

        //if item is a bouquet because this ones have this part empty.
        if (itemDrop.Bouquet == null)
        {
            //This is a loop that indicates how many times the instatiate would need to repeat
            for(int i = 0; i < 3; i++)
            {
                //This vector is to make the flower seperate form each other
                Vector3 separate = new Vector3(i * 0.5f, 0, 0);
                Instantiate(itemDrop.prefab, spawnPosition + separate, Quaternion.identity);    
            }
        }
        else 
        {
            Instantiate(itemDrop.prefab, spawnPosition, Quaternion.identity);
        }

        //remove item of inventory 
        Items.Remove(itemDrop);
        //tells UI
        ListItem();
    }

    //Bouquet flowers to bouquet method 
    public void FlowBouquet(Item flower)
    {
        int Count = 0;

        //For each flower of the same type count adds 1
        foreach(Item item in Items)
        {
            if (item == flower)
            {
                Count++;
            }
        }

        // if we have 3 of the same flower remove them and instead creat a
        // bouquet.
        if(Count >= 3)
        {
            int removed = 0;

            for(int i = Items.Count -1; i >=0; i--)
            {
                if(Items[i] == flower && removed < 3)
                {
                    Items.RemoveAt(i);
                    removed++;
                }
            }
            
            //adds the bouquet to the inventory
            Items.Add(flower.Bouquet);
        }

        //Updates UI inventory
        ListItem();
    }
}

