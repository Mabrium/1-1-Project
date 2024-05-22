using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeText : MonoBehaviour
{
    //public GameManager GM;
    public ModeChange MC;
    [SerializeField] TextMeshProUGUI mode_text;

    //private void Awake()
    //{
    //    GM = GetComponent<GameManager>();
    //}
    private void Start()
    {
        Texting();
    }
    public void Texting()
    {
        //if(GM.Mode == 1)
        //{
        //    ModeTexting("Hard Mode");
        //}
        //else
        //    ModeTexting("Normal Mode");
        if (MC.hardmodeOn)
        {
            //GM.Mode = 1;
            ModeTexting("Hard Mode");
        }
        else
            //GM.Mode = 0;
            ModeTexting("Normal Mode");
    }

    public void ModeTexting(string TextMeshProUGUI)
    {
        mode_text.text = TextMeshProUGUI;
    }


}
