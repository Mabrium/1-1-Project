using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{
    public FadeInOut Fade;
    void Start()
    {
        Fade.Fade();
    }
}
