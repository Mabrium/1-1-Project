using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSound : MonoBehaviour
{
    public AudioSource Sound; //���� ���� ������

    void Start()
    {
        Sound.volume = PlayerPrefs.GetFloat("musicVolume");
    }

}
