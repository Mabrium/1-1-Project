using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int SaveStage; //������ Ŭ����� �������� ��
    public float SaveSoundVoulme; //����� ���� ��

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
