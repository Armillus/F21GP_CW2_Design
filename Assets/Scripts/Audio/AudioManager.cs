using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public int         threshold = 3;

    [SerializeField]
    private AudioSource _currentMusic;

    private int         _beatsElapsed;

    void Start() 
    {
        _currentMusic.clip = playlist[0];

        FindObjectOfType<AudioProcessor>().onBeat.AddListener(OnBeatDetected);

        _currentMusic.Play(0);
    }

    void OnBeatDetected()
    {        
        if (_beatsElapsed++ == threshold)
        {
            ColorManager.updateColors();
            _beatsElapsed = 0;
        }
    }
}