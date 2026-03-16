using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDialogue : NPC
{
    [SerializeField] private DialogueHandler _dialogue;
    [SerializeField] private DialogueNode _dialogueStartNode;
    [SerializeField] private GameObject _ui;

    [SerializeField] private DialogueNode giftNode;
    [SerializeField] private Item Teddy;
    private bool GiftGiven = false;


    public GameObject interacttext;
    private DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _runningDialogue;
    private bool _waitingForPlayerResponse;
    private float _interactionDistance;


    private void Start()
    {
        _currentNode = _dialogueStartNode;
    }

    private void Update()
    {
        CheckDistance();
        DogCheck();
    }
    private void AdvanceDialogue()
    {
        _runningDialogue = true;

        //This checks if the current node is The "giftNode" and it cheacks if the player already 
        // has the gift with a bool. 
        if (_currentNode == giftNode && !GiftGiven)
        {
            //This adds The teddy to the inventory
            InventoryManager.Instance.Add(Teddy);
            GiftGiven = true;
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

    private void EndDialogue()
    {
        _runningDialogue = false;
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
        _dialogue.HideDialogue();
       
    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
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
