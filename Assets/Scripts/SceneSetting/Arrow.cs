using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public SceneMove SM;
    public void Right()
    {
        if (!SM.Moving)
        {
            if (!SM.Settinging)
            {
                SM.ScrollRight();
            }

        }
    }

    public void Left() 
    {
        if (!SM.Moving)
        {
            if (!SM.Settinging)
            {
                SM.ScrollLeft();
            }

        }
    }
}
