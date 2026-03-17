using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundmusic;
    public AudioSource track1;
    public AudioSource track2;
    public float fadeDuration = 1.0f;
    public static AudioManager instance;
    private bool isTrack1Playing = true;

    
   private  void Awake()
    {
       if (instance == null ) 
            instance = this;
    }


    private void Start()
    {
        track1 = GetComponent<AudioSource>();
        track2 = GetComponent<AudioSource>();
        isTrack1Playing=true;
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
