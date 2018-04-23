using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager {
    
    #region Singleton
    private static SoundManager instance;


    private SoundManager() {
        stingSource = GameObject.Find("CameraP1").GetComponent<AudioSource>();
        s1 = Resources.Load<AudioClip>("Sound/sound1");

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
    AudioClip s1;
    public float bpm = 128;




    public void Play() {
       stingSource.Play();
    }
}

