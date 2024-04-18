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
        if (MC.hardmodeOn)
        {
            ModeTexting("Hard Mode");
        }
        else
            ModeTexting("Normal Mode");
    }

    public void ModeTexting(string TextMeshProUGUI)
    {
        mode_text.text = TextMeshProUGUI;
    }


}
