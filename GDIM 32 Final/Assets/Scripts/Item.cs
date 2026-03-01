using UnityEngine;

//This es the script that make us able to create Scriptable Objects(exaple from W5?)

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]


public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject prefab; 
}

