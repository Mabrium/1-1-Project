using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STarT1 : MonoBehaviour
{
    public Image image;
    private float time = 0f; //���̵尡 �ǰ� �ִ� �ð�(�ǵ帱 �ʿ� ����)
    private float fadetime = 1.5f; //���̵� �ϴµ� �ɸ��� �ð�
    void Start()
    {
        StartCoroutine(Fadeout());
    }

    private IEnumerator Fadeout() //���̵� �ƿ��� �ؾ��� �� ����ϴ� ��
    {
        time = 0;
        Color alpha = image.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(1, 0, time);
            image.color = alpha;
            yield return null;
        }
        image.gameObject.SetActive(false);
    }
}
