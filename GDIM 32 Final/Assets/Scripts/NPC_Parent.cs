using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Parent : MonoBehaviour
{


    protected enum NpcState
    {
        walking, interacting
    }

    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _SightMaxDistance;
    [SerializeField] protected float _walkTimeMax = 3.0f;
    [SerializeField] protected Player _player;
    [SerializeField] protected float _obstacleCheckDistance = 1.0f;
    [SerializeField] protected float _obstacleCheckRadius = 1.0f;
    [SerializeField] protected float _walkSpeed;
    [SerializeField] protected float _rotateSpeed;
 




    protected NpcState _state;
    protected float _walkTime;
    protected Vector3 _walkDirection;
    protected Vector3 _spherecastHitLocation;

    protected void Update()
    {
        UpdateState();
        RunState();
    }

    protected void UpdateState()
    {
        if(player_close())
        {
            _state = NpcState.interacting;
        }
        else
        {
            _state = NpcState.walking;
        }
    }


    protected void RunState ()
    {
        switch(_state)
        {
            case NpcState.walking: 
            RunWalkingState(); 
            break;

            case NpcState.interacting: 
            RunIntState(); 
            break;

            default:
                Debug.LogError("unhandled state " + _state); 
                break;
        }
    }


    protected void RunWalkingState()
    {
        _walkTime -= Time.deltaTime;   

        if(_walkTime <= 0.0f)
        {
            _walkTime = _walkTimeMax;
            NewWalkDirection();
        }


        int attempts = 0;


        while(CloseObstacles() && attempts < 3)
        {
            NewWalkDirection();
            attempts ++;
        }

        _animator.SetBool("Walk", true);

        RotateTowards(_walkDirection);
        transform.Translate(_walkDirection * _walkSpeed * Time.deltaTime, Space.World);

    }


    protected void NewWalkDirection()
    {
        Vector3 randomDirec = Random.insideUnitCircle;
        _walkDirection = new Vector3(randomDirec.x, 0.0f, randomDirec.y);
        _walkDirection = _walkDirection.normalized;
    }


    protected bool CloseObstacles()
    {

        RaycastHit hitInfo;
        bool hasObstacle = Physics.SphereCast(
            transform.position,
            _obstacleCheckRadius,
            _walkDirection,
            out hitInfo,
            _obstacleCheckDistance
        );

        if(hasObstacle)
        {
            _spherecastHitLocation = hitInfo.point;
        }

        return hasObstacle;
    }

    protected void RunIntState()
    {
        Vector3 playerP = _player.transform.position;
        Vector3 lookatDirec = playerP - transform.position;
        lookatDirec.y = 0.0f;

        if (lookatDirec != Vector3.zero)
        {
            transform.forward = lookatDirec;
        }

        _animator.SetBool("Walk", false);


    }


    protected bool player_close()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        return distance < _SightMaxDistance;
    }

    protected void RotateTowards(Vector3 direction)
    {
        Vector3 currentForward = new Vector3(transform.forward.x, 0, transform.forward.z);
        Vector3 newForward = Vector3.RotateTowards(currentForward, direction, _rotateSpeed * Time.deltaTime, 0.0f);
        transform.forward = newForward;
    }
}
