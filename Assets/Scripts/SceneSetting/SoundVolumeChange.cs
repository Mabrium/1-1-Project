using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeChange : MonoBehaviour
{

    public static SoundVolumeChange Instance;

    [SerializeField] Slider SoundVolume;
    public AudioSource SoundSource;

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    private void Start()
    {
        SoundVolume.onValueChanged.AddListener(x => SoundSource.volume = x);
        //if (PlayerPrefs.HasKey("musicVolume"))
        //{
        //    Load();
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    if (!PlayerPrefs.HasKey("musicVolume"))
        //    {
        //        Save();
        //    }
        //}
    }





    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", SoundVolume.value);
    }

    public void Load()
    {
        SoundVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }

}
