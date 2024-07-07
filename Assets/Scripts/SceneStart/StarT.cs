using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarT : MonoBehaviour
{
    public Image image;

    private float time = 0f; //���̵尡 �ǰ� �ִ� �ð�(�ǵ帱 �ʿ� ����)
    private float fadetime = 0.5f; //���̵� �ϴµ� �ɸ��� �ð�
    void Start()
    {
        StartCoroutine(Fadeout());
    }

    private IEnumerator Fadeout() //���̵� �ƿ��� �ؾ��� �� ����ϴ� ��
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
