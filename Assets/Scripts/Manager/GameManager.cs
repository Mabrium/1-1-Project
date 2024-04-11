using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int SaveStage; //저장할 클리어된 스테이지 값
    public float SaveSoundVoulme; //저장된 사운드 값

    void Start()
    {
        LoadData();
    }


    void Update()
    {
        
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Stage", SaveStage);
        PlayerPrefs.SetFloat("Sound", SaveSoundVoulme);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        int StageX = PlayerPrefs.GetInt("Stage");
        float SoundX = PlayerPrefs.GetFloat("Sound");

    }
}
