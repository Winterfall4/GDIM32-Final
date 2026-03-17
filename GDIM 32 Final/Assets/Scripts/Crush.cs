using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrushState
{
    StartMode,
    FlowerMode,
    PresentMode

}
public class Crush : Dialogue
{
    [SerializeField] private DialogueNode presentNode;
    [SerializeField] private DialogueNode flowerNode;
    [SerializeField] private DialogueNode rightPresentNode;
    [SerializeField] private DialogueNode rightFlowerNode;
    [SerializeField] private Item Teddy;

    private bool playerInRange = false;
    public delegate void PlayerInteract();
    public static event PlayerInteract OnPlayerClick;
    public CrushState _currentMode;

    
    private void Start()
    {
        _currentNode = _dialogueStartNode;
        _currentMode = CrushState.StartMode;
    }
    

    private void Update()
    {
        CheckDistance();
        CrushCheck();
        if (InventoryManager.Instance.PlayerHasItem(Teddy)) 
        {
            Debug.Log("TEDDY IN INVENTORY");
            _currentNode = presentNode;

        }
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

    public override void AdvanceDialogue()
    {
        _runningDialogue = true;

        if (_currentNode == rightPresentNode)
        {
            _currentNode = flowerNode;
            InventoryManager.Instance.Remove(Teddy);
            InventoryManager.Instance.ListItem();
        }

        if (_currentLine < _currentNode._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            // show player dialogue options, if there are any
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else
        {
            // if there are no NPC or player lines left, close dialogue UI
            EndDialogue();
            Cursor.lockState = CursorLockMode.Locked;
            // CrushMode();
        }
    }

    /*
    private void CrushMode()
    {
        switch (_currentMode)
        {
            case CrushState.StartMode:
                _currentNode = presentNode;
                break;

            case CrushState.PresentMode:
                if (_currentNode == rightPresentNode)
                {
                    _currentNode = flowerNode;
                }
                break;

        }
    }
    */
}
    