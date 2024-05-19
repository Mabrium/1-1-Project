using System.Collections;
using UnityEngine;

public class ChoiceBox : MonoBehaviour
{
    private float time = 0f; //페이드가 되고 있는 시간(건드릴 필요 없음)
    private float fadetime = 0.5f; //페이드 하는데 걸리는 시간
    public SpriteRenderer Sr;

    private void Awake()
    {
        Sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        StartCoroutine(Fadeinout());
    }

    
    private IEnumerator Fadeinout() //페이드 인 아웃
    {
        time = 0f; //초기화
        Color alpha = Sr.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(0, 1, time);
            Sr.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return new WaitForSeconds(0.5f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadetime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Sr.color = alpha;
            yield return null;
        }
        yield return StartCoroutine(Fadeinout());
    }
}
