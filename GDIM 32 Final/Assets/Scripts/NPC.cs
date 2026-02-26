using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


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


    public void CheckDistance()
    {
        _distance = (transform.position - _player.transform.position).sqrMagnitude;

        if (_distance < _talkingDistance)
        {
            _currentState = NPCState.isTalking;
        }

        else
        {
            _currentState = NPCState.isIdle;
        }
    }
}


