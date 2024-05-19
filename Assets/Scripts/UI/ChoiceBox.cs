using System.Collections;
using UnityEngine;

public class ChoiceBox : MonoBehaviour
{
    private float time = 0f; //���̵尡 �ǰ� �ִ� �ð�(�ǵ帱 �ʿ� ����)
    private float fadetime = 0.5f; //���̵� �ϴµ� �ɸ��� �ð�
    public SpriteRenderer Sr;

    private void Awake()
    {
        Sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        StartCoroutine(Fadeinout());
    }

    
    private IEnumerator Fadeinout() //���̵� �� �ƿ�
    {
        time = 0f; //�ʱ�ȭ
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
