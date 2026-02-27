using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : NPC
{
    private bool playerInRange = false;
    public delegate void PlayerInteract();
    public static event PlayerInteract OnPlayerClick;
    public GameObject interacttext;
    [SerializeField] private GameObject _ui;

    private void Start()
    {
        
        interacttext.SetActive(false);  
    }

    /*
    void Update()
    {
        // If player is in range and presses 'E'
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            interacttext.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
    
           
           interacttext.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            
            if (Locator.Instance != null)
            {
                Locator.Instance.CrushUI.SetActive(false);
                interacttext.SetActive(false);
            }

            
           
        }
    }

    void Interact()
    {
        OnPlayerClick.Invoke();
       
    }
    */

    private void Update()
    {
        CheckDistance();
        CrushCheck();
    }

    private void CrushCheck()
    {
        switch (_currentState)
        {
            case NPCState.isIdle:
                playerInRange = false;
                Locator.Instance.CrushUI.SetActive(false);
                interacttext.SetActive(false);
                break;
            case NPCState.isTalking:
                playerInRange = true;
                interacttext.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _ui.SetActive(true);
                }
                break;
        }
    }
}