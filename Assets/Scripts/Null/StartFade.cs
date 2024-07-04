using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{
    public FadeInOut Fade;
    void Start()//씬이 시작되었을 때 페이트 시켜주기
    {
        Fade.Fade();
    }
}
