using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSound : MonoBehaviour
{
    public AudioSource Sound; //º¼·ý »ç¿îµå °¡Á®¿È

    void Start()
    {
        Sound.volume = PlayerPrefs.GetFloat("musicVolume");
    }

}
