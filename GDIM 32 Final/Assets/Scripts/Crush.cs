using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : Dialogue
{
    private bool playerInRange = false;
    public delegate void PlayerInteract();
    public static event PlayerInteract OnPlayerClick;


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
                interacttext.SetActive(false);
                break;
            case NPCState.isTalking:
                interacttext.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
                {
                    AdvanceDialogue();
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    //EndDialogue();
                }
                break;
        }
    }
}