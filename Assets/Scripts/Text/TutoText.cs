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


    private IEnumerator tText()
    {
        yield return new WaitForSeconds(10f);
        Text[0].SetActive(false);
        Text[1].SetActive(true);
        yield return new WaitForSeconds(10f);
        Text[1].SetActive(false);
        Text[2].SetActive(true);
    }

}
