using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    public FadeBloom FB;

    void Start()
    {
        Time.timeScale = 1;
        FB.BloomFade();
    }

}
