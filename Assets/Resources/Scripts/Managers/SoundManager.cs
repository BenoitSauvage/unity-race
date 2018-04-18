using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager {

    #region Singleton
    private static SoundManager instance;


    private SoundManager() {
    }

    public static SoundManager Instance {
        get {
            if (instance == null) {
                instance = new SoundManager();
            }
            return instance;
        }
    }

    #endregion

    public AudioSource stingSource;
    public float bpm = 128;




    public void Play() {

       stingSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
       AudioClip s1 = Resources.Load<>

       stingSource.Play();
    }
  
}
