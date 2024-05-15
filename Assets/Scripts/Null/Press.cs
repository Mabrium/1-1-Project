using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Press : MonoBehaviour
{
    public FadeInOut Fade;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(Starting());
        }
    }


    IEnumerator Starting()
    {
        Fade.Fade();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu");
    }

    
}
