using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    public bool hardmodeOn = false;
    public void HardMode()
    {
        hardmodeOn = true;
    }

    public void NormalMode()
    {
        hardmodeOn = false;
    }
}
