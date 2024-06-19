using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundVolumeChange SVC; //���ǵ� ���� ���� �ڵ� ��������
    public ModeChange MC;
    public int SaveStage; //������ Ŭ����� �������� ��
    
    //public int Mode;

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
        //int SaveStage = PlayerPrefs.GetInt("Stage");
        SVC.Load();
        MC.Load();
    }

    
}
