using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : NPC
{
    [SerializeField] protected DialogueHandler _dialogue;
    [SerializeField] protected DialogueNode _dialogueStartNode;
    [SerializeField] protected GameObject _ui;

    public GameObject interacttext;
    [SerializeField] protected DialogueNode _currentNode;
    protected int _currentLine = 0;
    protected bool _runningDialogue;
    protected bool _waitingForPlayerResponse;
    protected float _interactionDistance;


    private void Start()
    {
        _currentNode = _dialogueStartNode;
    }

    public virtual void AdvanceDialogue()
    {
        _runningDialogue = true;

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

    public virtual void EndDialogue()
    {
        _runningDialogue = false;
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
        _dialogue.HideDialogue();

    }

    public void SelectedOption(int option)
    {
        if (_isTalkingToNPC == true)
        {
            _currentLine = 0;
            _waitingForPlayerResponse = false;

            _currentNode = _currentNode._npcReplies[option];
            AdvanceDialogue();
        }
    }

}
