using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Press : MonoBehaviour
{
    public FadeBloom FB;
    public FadeInOut Fade;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(Starting());
        }
    }


    IEnumerator Starting()
    {
        FB.StartFade();
        Fade.Fade();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu");
    }

    
}
