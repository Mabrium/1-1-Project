using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    public Image fade_in_out; //페이드 인 아웃할 이미지
    private float time = 0f; //페이드가 되고 있는 시간(건드릴 필요 없음)
    private float fadetime = 1.5f; //페이드 하는데 걸리는 시간

    public void Fade() //외부에서 불러올때를 위한 함수
    {
        StartCoroutine(Fadeinout());
    }

    private IEnumerator Fadeinout() //페이드 인 아웃 --- 페이드 인을 했다가 아웃하게 되며 위치만 이동한다면 사용을 하는 것
    {
        fade_in_out.gameObject.SetActive(true); //비활성화된 페이드 이미지 활성화하기
        time = 0f; //초기화
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

    private IEnumerator Fadein() //페이드 인만 해야할 때 사용하는 것
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

    private IEnumerator Fadeout() //페이드 아웃만 해야할 때 사용하는 것
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
