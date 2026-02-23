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

    void Interact()
    {
        OnPlayerClick.Invoke();
        Debug.Log("Interacted with Crush");
    }
}