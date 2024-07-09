using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioChange : MonoBehaviour
{
    public static AudioChange instance;

    public AudioClip[] Audio;
    public AudioSource AS;

    private bool isPlaying;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //if(SceneManager.GetActiveScene().name == "Menu")
        //{
        //    isPlaying = true;
        //    Debug.Log("Playing");
            
        //}
    }

    public void PlayBGM()
    {
        AS.clip = Audio[0];
        AS.Play();
    }

}
