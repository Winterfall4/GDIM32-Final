using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    private bool playerInRange = false;
    public delegate void PlayerInteract();
    public static event PlayerInteract OnPlayerClick;

    void Update()
    {
        // If player is in range and presses 'E'
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press E to interact");
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Disable the Crush UI when player walks away
            if (Locator.Instance != null)
            {
                Locator.Instance.CrushUI.SetActive(false);
            }

            Debug.Log("Player left crush range");
        }
    }

    void Interact()
    {
        OnPlayerClick.Invoke();
        Debug.Log("Interacted with Crush");
    }
}