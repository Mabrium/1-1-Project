using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarT : MonoBehaviour
{
    public Image image;

    private float time = 0f; //페이드가 되고 있는 시간(건드릴 필요 없음)
    private float fadetime = 0.5f; //페이드 하는데 걸리는 시간
    void Start()
    {
        StartCoroutine(Fadeout());
    }

    private IEnumerator Fadeout() //페이드 아웃만 해야할 때 사용하는 것
    {
        yield return new WaitForSeconds(5f);
        time = 0f;
        Color alpha = image.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(0, 1, time);
            image.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("Starting");
    }
}
