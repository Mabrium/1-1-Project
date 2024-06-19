using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    public ModeText MT;
    public int Mode = 0;

    public void NormalMode()
    {
        Mode = 0;
        PlayerPrefs.SetInt("mode", Mode);
        MT.Texting();
    }
    public void HardMode()
    {
        Mode = 1;
        PlayerPrefs.SetInt("mode", Mode);
        MT.Texting();
    }

    public void Load()
    {
        Mode = PlayerPrefs.GetInt("mode");
    }
}
