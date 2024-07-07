using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STarT1 : MonoBehaviour
{
    public Image image;
    private float time = 0f; //���̵尡 �ǰ� �ִ� �ð�(�ǵ帱 �ʿ� ����)
    private float fadetime = 0.5f; //���̵� �ϴµ� �ɸ��� �ð�
    void Start()
    {
        
    }

    private IEnumerator Fadeout() //���̵� �ƿ��� �ؾ��� �� ����ϴ� ��
    {
        Color alpha = image.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(1, 0, time);
            image.color = alpha;
            yield return null;
        }
    }
}
