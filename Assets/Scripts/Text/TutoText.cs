using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoText : MonoBehaviour
{
    public GameObject Text;

    private void Start()
    {
        
    }

    private void ChnageText()
    {
        StartCoroutine(Text1());
    }

    private IEnumerator Text1()
    {
        yield return null;
    }

}
