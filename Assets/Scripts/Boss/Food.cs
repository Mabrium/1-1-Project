using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject _target;
    public Transform _p1, _p2, _p3;
    public float _duration;
    public GameObject[] FOOD;
    public Transform[] Right_transforms;
    public Transform[] Left_transforms;
    void Start()
    {
        StartCoroutine(COR_BezierCurves());
    }

    //private IEnumerator Throw()
    //{
        
    //}
    IEnumerator COR_BezierCurves(float duration = 1.0f)
    {
        float time = 0f;

        while (true)
        {
            if (time > 1f)
            {
                time = 0f;
            }

            Vector3 p4 = Vector3.Lerp(_p1.position, _p2.position, time);
            Vector3 p5 = Vector3.Lerp(_p2.position, _p3.position, time);
            _target.transform.position = Vector3.Lerp(p4, p5, time);

            time += Time.deltaTime / duration;

            yield return null;
        }
    }

    private IEnumerator ThrowRight()
    {
        for(int i = 0; i < 5; i++)
        {
            _p2 = Right_transforms[i];
            _p3 = Right_transforms[i * 2];
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator ThrowLeft()
    {
        for (int i = 0; i < 5; i++)
        {
            _p2 = Left_transforms[i];
            _p3 = Left_transforms[i * 2];
            yield return new WaitForSeconds(1f);
        }
    }
}
