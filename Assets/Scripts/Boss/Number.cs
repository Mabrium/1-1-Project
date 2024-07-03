using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    public Sprite[] NUMBER;
    private SpriteRenderer SR;
    public int random;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }


    private void OnEnable()
    {
        StartCoroutine(CountNumber());
    }

    public IEnumerator CountNumber()
    {
        for(int i = 0; i < 8; i++)
        {
            random = Random.Range(0, 9);
            SR.sprite = NUMBER[random];
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
