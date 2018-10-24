using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuBehavior : MonoBehaviour {

    public Slider volume;
    public Dropdown graphics;
    public Toggle fullscreen;

    private void Start()
    {
        volume.onValueChanged.AddListener(delegate { ChangeVolume(); });
        graphics.onValueChanged.AddListener(delegate { ChangeResolution(); });
        fullscreen.onValueChanged.AddListener(delegate { ChangeFullscreen(); });
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
    }

    public void ChangeResolution()
    {
        int middleIndex = Screen.resolutions.Length / 2; 

        if (graphics.value == 0)
            Screen.SetResolution(Screen.resolutions[0].width, Screen.resolutions[0].height, fullscreen.isOn);
        else if (graphics.value == 1)
            Screen.SetResolution(Screen.resolutions[middleIndex].width, Screen.resolutions[middleIndex].height, fullscreen.isOn);
        else Screen.SetResolution(Screen.resolutions[Screen.resolutions.Length - 1].width, Screen.resolutions[Screen.resolutions.Length - 1].height, fullscreen.isOn);
    }

    public void ChangeFullscreen()
    {
        Screen.SetResolution(Screen.width, Screen.height, fullscreen.isOn);
    }
}
