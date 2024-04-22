using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundVolumeChange SVC; //���ǵ� ���� ���� �ڵ� ��������
    //private static GameManager Instance = null;
    public int SaveStage; //������ Ŭ����� �������� ��
    public float SaveSoundVoulme; //����� ���� ��

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
