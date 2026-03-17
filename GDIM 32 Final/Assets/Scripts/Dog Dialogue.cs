using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDialogue : Dialogue
{
 
    [SerializeField] private DialogueNode giftNode;
    [SerializeField] private Item Teddy;
    private bool GiftGiven = false;
    [SerializeField] private GameObject DesactivateTeddy;
    


    private void Update()
    {
        CheckDistance();
        DogCheck();
    }
    public override void AdvanceDialogue()
    {
        _runningDialogue = true;

        //This checks if the current node is The "giftNode" and it cheacks if the player already 
        // has the gift with a bool. 
        if (_currentNode == giftNode && !GiftGiven)
        {
            bool TeddyAdded = InventoryManager.Instance.Add(Teddy);
            //This adds The teddy to the inventory
            if(TeddyAdded)
            {
                GiftGiven = true;
                DesactivateTeddy.SetActive(false);
            }
        }
       

        if (_currentLine < _currentNode._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            // show player dialogue options, if there are any
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else
        {
            // if there are no NPC or player lines left, close dialogue UI
            EndDialogue();
        }
    }

    private void DogCheck()
    {
        switch (_currentState)
        {
            case NPCState.isIdle:
                Locator.Instance.DogUI.SetActive(false);
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
