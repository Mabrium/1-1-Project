using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    public Image fade_in_out; //���̵� �� �ƿ��� �̹���
    private float time = 0f; //���̵尡 �ǰ� �ִ� �ð�(�ǵ帱 �ʿ� ����)
    private float fadetime = 1.5f; //���̵� �ϴµ� �ɸ��� �ð�

    public void Fade() //�ܺο��� �ҷ��ö��� ���� �Լ�
    {
        StartCoroutine(Fadeinout());
    }

    private IEnumerator Fadeinout() //���̵� �� �ƿ� --- ���̵� ���� �ߴٰ� �ƿ��ϰ� �Ǹ� ��ġ�� �̵��Ѵٸ� ����� �ϴ� ��
    {
        fade_in_out.gameObject.SetActive(true); //��Ȱ��ȭ�� ���̵� �̹��� Ȱ��ȭ�ϱ�
        time = 0f; //�ʱ�ȭ
        Color alpha = fade_in_out.color; 
        while (alpha.a <  1f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fade_in_out.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return new WaitForSeconds(1f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fade_in_out.color = alpha;
            yield return null;
        }
        fade_in_out.gameObject.SetActive(false);
        yield return null;
    }

    private IEnumerator Fadein() //���̵� �θ� �ؾ��� �� ����ϴ� ��
    {
        fade_in_out.gameObject.SetActive(true);
        time = 0f;
        Color alpha = fade_in_out.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fade_in_out.color = alpha;
            yield return null;
        }
    }

    private IEnumerator Fadeout() //���̵� �ƿ��� �ؾ��� �� ����ϴ� ��
    {
        Color alpha = fade_in_out.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fade_in_out.color = alpha;
            yield return null;
        }
        fade_in_out.gameObject.SetActive(false);
        yield return null;
    }
}
