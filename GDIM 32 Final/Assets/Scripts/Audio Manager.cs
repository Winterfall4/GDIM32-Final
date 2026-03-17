using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundmusic;
    private AudioSource track1, track2;
    public static AudioManager instance;
    private bool isTrack1Playing = true;

    
   private  void Awake()
    {
       if (instance == null ) 
            instance = this;
    }


    private void Start()
    {
        track1 = gameObject.AddComponent<AudioSource>();
        track2 = gameObject.AddComponent<AudioSource>();
        isTrack1Playing =true;
        SwapTrack(backgroundmusic);
    }

    public void SwapTrack(AudioClip newclip)
    { if (isTrack1Playing)
        { track2.clip = newclip;
            track2.Play();
                track1.Stop(); }
        else
        { track1.clip = newclip;
            track1.Play();
                    track2.Stop(); }
    }
    public void ReturnToDefault()
    { SwapTrack(backgroundmusic); }
}
