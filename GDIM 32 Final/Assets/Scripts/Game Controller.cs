using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public Player Player { get; private set; }
    public GameObject CrushUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        GameObject playerObj = GameObject.FindWithTag("Player");
        Player = playerObj.GetComponent<Player>();
    }
    private void Start()
    {

        CrushUI.SetActive(false);
    }

    void OnEnable()
    {
        Crush.OnPlayerClick += CrushScene;
    }
    public void CrushScene()
    { CrushUI.SetActive(true);
        }
}
