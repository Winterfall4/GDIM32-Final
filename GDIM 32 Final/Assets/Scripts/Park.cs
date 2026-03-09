using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park : MonoBehaviour
{

    [SerializeField] BoxCollider _Collider;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _Collider.enabled = false;

            Invoke("ActivarCollider", 3f);
        }


    }

    void ActivarCollider()
    {
        _Collider.enabled = true;
    }
}

