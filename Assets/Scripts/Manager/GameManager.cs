using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundVolumeChange SVC; //음악등 사운드 볼륨 코드 가져오기
    //private static GameManager Instance = null;
    public int SaveStage; //저장할 클리어된 스테이지 값
    public float SaveSoundVoulme; //저장된 사운드 값

    //private void Awake()
    //{
    //    Instance = this;
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        //DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Instance = this;
    //        Destroy(gameObject);
    //    }
    //    DontDestroyOnLoad(gameObject);
    //}
    void Start()
    {
        LoadData();
    }


    public void SaveData()
    {
        PlayerPrefs.SetInt("Stage", SaveStage);
        SVC.Save();
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        int SaveStage = PlayerPrefs.GetInt("Stage");
        SVC.Load();
    }
}
