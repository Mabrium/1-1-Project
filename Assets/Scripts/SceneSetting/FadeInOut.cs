using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    public Image fadeinout;
    private float time = 0f;
    private float fadetime = 2.5f;

    public void Fade()
    {
        StartCoroutine(FI());
    }

    private IEnumerator FI()
    {
        fadeinout.gameObject.SetActive(true);
        time = 0f;
        Color alpha = fadeinout.color;
        while (alpha.a <  1f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadeinout.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return new WaitForSeconds(1f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadeinout.color = alpha;
            yield return null;
        }
        fadeinout.gameObject.SetActive(false);
        yield return null;
    }
}
