using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundVolumeChange SVC; //음악등 사운드 볼륨 코드 가져오기
    public ModeChange MC;


    void Awake()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.Save();
    }

    
    void LoadData()
    {
        SVC.Load();
        MC.Load();
    }
}
