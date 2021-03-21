using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropwdon;

    private Resolution[] resolutions;

    public void Start()
    {
        Screen.fullScreen = false;

        resolutions = AvailableResolutions();
        resolutionDropwdon.ClearOptions();

        resolutionDropwdon.AddOptions(ResolutionsOptions());
        resolutionDropwdon.value = CurrentResolutionIndex();
        resolutionDropwdon.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];

        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    private Resolution[] AvailableResolutions()
    {
        return Screen.resolutions.Select(res => new Resolution { 
            width  = res.width,
            height = res.height
        }).Distinct().ToArray();
    }

    private List<string> ResolutionsOptions()
    {
        List<string> options = new List<string>();

        foreach (Resolution res in resolutions)
        {
            options.Add(res.width + "x" + res.height);
        }
        return options;
    }

    private int CurrentResolutionIndex()
    {
        for (int i = 0; i < resolutions.Length; ++i)
        {
            if (IsCurrentResolution(resolutions[i]))
                return i;
        }
        return 0;
    }

    private bool IsCurrentResolution(Resolution res)
    {
        return Screen.width == res.width && Screen.height == res.height;
    }
}
