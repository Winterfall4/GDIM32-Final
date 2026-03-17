using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public AudioClip newtrack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            AudioManager.instance.SwapTrack(newtrack);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Player"))
        { AudioManager.instance.ReturnToDefault(); }
    }
}
