using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCState
{
    isIdle,
    isTalking
}
public class NPC : MonoBehaviour
{

    public NPCState _currentState;
    public float _talkingDistance;
    public float _distance;
    [SerializeField] public GameObject _player;

    protected bool _isTalkingToNPC;


    public void CheckDistance()
    {
        _distance = (transform.position - _player.transform.position).sqrMagnitude;

        if (_distance < _talkingDistance)
        {
            _currentState = NPCState.isTalking;
            _isTalkingToNPC = true;
        }

        else
        {
            _currentState = NPCState.isIdle;
            _isTalkingToNPC = false;
        }
    }
}