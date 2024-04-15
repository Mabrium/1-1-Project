using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance = null;
    public int SaveStage; //������ Ŭ����� �������� ��
    public float SaveSoundVoulme; //����� ���� ��

    private void Awake()
    {
        Instance = this;
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance = this;
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
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
        int SaveStage = PlayerPrefs.GetInt("Stage");
        float SaveSoundVoulme = PlayerPrefs.GetFloat("Sound");

    }
}
