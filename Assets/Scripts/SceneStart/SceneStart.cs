using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{

    void Start()
    {
        AudioChange.instance.PlayBGM();
        Time.timeScale = 1;
    }

}
