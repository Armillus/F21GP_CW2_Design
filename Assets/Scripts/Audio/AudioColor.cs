using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Track
{
    public AudioClip clip;
    [Range(20,120)]
    public int BPM=30;
    public float startingTime;
}

public class AudioColor : MonoBehaviour
{
    public AudioSource sourceAudio;
    public Track[] tracks;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        if (sourceAudio != null && tracks.Length>0)
        {
            sourceAudio.Stop();
            index = 0;
            Invoke("startSong", 1f);
        }
    }

    private void startSong()
    {
        Track t = tracks[index];
        if (t.BPM == 0) { t.BPM = 20; }
        sourceAudio.clip = t.clip;
        sourceAudio.Play();
        InvokeRepeating("callColors", t.startingTime, 60.0f / (float)t.BPM);
    }


    private void callColors()
    {
        ColorManager.updateColors();
        if (!sourceAudio.isPlaying)
        {
            nextMusic();
        }
    }

    public void nextMusic()
    {
        int next = (index + 1) % tracks.Length;
        if(sourceAudio != null)
        {
            CancelInvoke();
            sourceAudio.Stop();
            index = next;
            startSong();
        }
    }
}
