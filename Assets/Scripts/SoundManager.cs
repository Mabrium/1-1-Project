using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeChange : MonoBehaviour
{
    public Slider SoundVolume;
    public AudioSource SoundSource;

    private void Start()
    {
        SoundVolume.onValueChanged.AddListener(x => SoundSource.volume = x);
    }
}
