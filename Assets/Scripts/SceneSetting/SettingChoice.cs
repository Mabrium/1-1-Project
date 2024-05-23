using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingChoice : MonoBehaviour
{
    public GameObject icon;
    private enum SettingMode
    {
        Sound,
        PlayMode
    }
    private SettingMode settingmode;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void ChoiceST()
    {
        switch (settingmode)
        {
            case SettingMode.Sound:
                //icon.
                break;
            case SettingMode.PlayMode:
                break;
        }
    }
}
