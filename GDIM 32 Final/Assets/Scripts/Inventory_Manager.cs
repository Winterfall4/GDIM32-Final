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


    public void Add(Item item)
    {
        //Debug.Log("Se llamó Add()");

        //PickUp items are here
        Items.Add(item);
        //This calls the list to update UI 
        ListItem();
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

            //Debug.Log(obj.transform.Find("ItemName"));
            //Debug.Log(obj.transform.Find("Item_Icon"));

            //This makes the image and name visible on the screen.
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }
}

