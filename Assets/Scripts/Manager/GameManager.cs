using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundVolumeChange SVC; //���ǵ� ���� ���� �ڵ� ��������
    public ModeChange MC;
    public int SaveStage; //������ Ŭ����� �������� ��


    void Awake()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Stage", SaveStage);

        PlayerPrefs.Save();
    }

    
    void LoadData()
    {
        SVC.Load();
        MC.Load();
    }
}
