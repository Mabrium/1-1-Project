using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    public ModeText MT;
    public bool hardmodeOn = false;
    public void HardMode()
    {
        hardmodeOn = true;
        MT.Texting();
    }

    public void NormalMode()
    {
        hardmodeOn = false;
        MT.Texting();
    }
}
