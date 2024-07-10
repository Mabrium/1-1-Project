using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioChange : MonoBehaviour
{
    public static AudioChange instance;

    public AudioClip[] Audio;
    public AudioSource AS;
    


    private void Awake()
    {
        instance = this;
    }



    public void PlayBGM()
    {
        if (SceneManager.GetActiveScene().name == "Menu") { AS.clip = Audio[0]; }
        if (SceneManager.GetActiveScene().name == "Library") { AS.clip = Audio[1]; }
        if (SceneManager.GetActiveScene().name == "Tutorial") { AS.clip = Audio[2]; }
        if (SceneManager.GetActiveScene().name == "Boss") { AS.clip = Audio[3]; }
        AS.Play();
    }

    public void LoadSound()
    {
        AS.volume = PlayerPrefs.GetFloat("musicVolume");
    }

}
