using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public Scrollbar mainScrollbar;

    public void VolumeControl(float volumeControl)
    {
        AudioListener.volume = mainScrollbar.value;
    }
}
