using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoText : MonoBehaviour
{
    
    public GameObject[] Text;

    private void Start()
    {
        StartCoroutine(tText());
    }


    private IEnumerator tText() //시간에 따라 텍스트 오브젝트를 활성화 및 비활성화
    {
        yield return new WaitForSeconds(10f);
        Text[0].SetActive(false);
        Text[1].SetActive(true);
        yield return new WaitForSeconds(10f);
        Text[1].SetActive(false);
        Text[2].SetActive(true);
        yield return new WaitForSeconds(10f);
        Text[2].SetActive(false);
        Text[3].SetActive(true);
    }

}
