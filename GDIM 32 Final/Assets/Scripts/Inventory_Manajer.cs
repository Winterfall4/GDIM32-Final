using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    //private void Start()
    //{
    //  Debug.Log("InventoryManager está activo");
    //}


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
        Items.Add(item);
        ListItem();
    }


    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItem()
    {
        //Debug.Log("ListItem se está ejecutando");

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("Item_Icon").GetComponent<Image>();

            Debug.Log(obj.transform.Find("ItemName"));
            Debug.Log(obj.transform.Find("Item_Icon"));

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }
}

