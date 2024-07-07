using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundVolumeChange SVC; //���ǵ� ���� ���� �ڵ� ��������
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
