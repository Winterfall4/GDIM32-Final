using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : NPC
{

    private bool playerInRange = false;
    public GameObject interacttext;
    [SerializeField] private GameObject _ui;

    private void Start()
    {

        interacttext.SetActive(false);
    }

    private void Update()
    {
        CheckDistance();
        DogCheck();
    }

    private void DogCheck()
    {
        switch (_currentState)
        {
            case NPCState.isIdle:
                playerInRange = false;
                Locator.Instance.DogUI.SetActive(false);
                interacttext.SetActive(false);
                break;
            case NPCState.isTalking:
                playerInRange = true;
                interacttext.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _ui.SetActive(true);
                }
                break;
        }
    }
}
