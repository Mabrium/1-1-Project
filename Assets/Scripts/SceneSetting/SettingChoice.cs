using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingChoice : MonoBehaviour
{
    public RectTransform icon_rect;
    public GameObject icon;
    private SettingMode settingmode;
    private enum SettingMode
    {
        Sound,
        PlayMode
    }

    private void Awake()
    {
        icon_rect = GetComponent<RectTransform>();
    }
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
                icon_rect.localPosition = new Vector2(-6, 2);
                break;
            case SettingMode.PlayMode:
                icon_rect.localPosition = new Vector2(-6, -1);
                break;
        }
    }
}
