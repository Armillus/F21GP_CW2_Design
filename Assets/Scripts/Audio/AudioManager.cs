using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;

    [SerializeField]
    private AudioSource _currentMusic;

    private float _averageLoudness = 0.0037f;
    private float _timeToWait;

    void Start() 
    {
        _currentMusic.clip = playlist[0];

        FindObjectOfType<AudioProcessor>().onSpectrum.AddListener(OnSpectrum);

        _currentMusic.Play(0);
    }

    void Update()
    {
        if (_timeToWait > 0f)
            _timeToWait -= Time.deltaTime;
    }

    void OnSpectrum(float[] spectrum)
    {
        if (_timeToWait > 0)
            return;

        float clipLoudness = 0f;

        for (int i = 0; i < spectrum.Length; ++i)
        {
            clipLoudness += Math.Abs(spectrum[i]);
        }
        clipLoudness /= spectrum.Length;

        Debug.Log(clipLoudness);

        if (clipLoudness > _averageLoudness)
        {
            ColorManager.updateColors();
            _timeToWait = 0.5f;
            //FindObjectOfType<AudioProcessor>().changeCameraColor();
        }

        //float[] loudness = { _averageLoudness, clipLoudness };
        //_averageLoudness = loudness.Average();
    }
}