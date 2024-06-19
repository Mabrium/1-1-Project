using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeText : MonoBehaviour
{
    public ModeChange MC;
    [SerializeField] TextMeshProUGUI mode_text;

    private void Start()
    {
        Texting();
    }
    public void Texting()
    {
        if (MC.Mode == 0)
        {
            ModeTexting("Normal Mode");
        }
        if (MC.Mode == 1)
        {
            ModeTexting("Hard Mode");
        }
    }

    public void ModeTexting(string TextMeshProUGUI)
    {
        mode_text.text = TextMeshProUGUI;
    }


}
