using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;




    
  


public class AudioManadger : MonoBehaviour
{
    public AudioClip[] AllAc;

    public AudioSource soundgame;

    public static AudioManadger _instanteat;

    public void Start()
    {
        if (_instanteat) Destroy(_instanteat);
        _instanteat = this;
        
    }

    public void StartGameSound()
    {
        soundgame.PlayOneShot(AllAc[0]);
        
    }


    public void PlaySoundTrigger(int number_audio)
    {
        soundgame.PlayOneShot(AllAc[number_audio]);

    }


}
