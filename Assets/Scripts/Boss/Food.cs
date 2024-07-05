using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject Coordinates;
    public GameObject _TARGET;
    public Transform _p1, _p2, _p3;
    public float _duration;
    public GameObject[] FOOD;
    public Transform[] transforms;

    private int ew = 0;
    void Start()
    {
        
    }

    public IEnumerator TThrow()
    {
        while (true)
        {
            Coordinates.transform.position = new Vector2(-0.4f, -0.5f);
            _TARGET = FOOD[ew];
            Coordinates.transform.position = new Vector2(-0.4f, -0.5f);
            ew++;
            if (ew > 4) ew = 0;
            yield return new WaitForSeconds(1f);
            Coordinates.transform.position = new Vector2(-0.4f, -0.5f);
        }
    }
    public IEnumerator TTThrow()
    {
        while (true)
        {
            Coordinates.transform.position = new Vector2(0.3f, -0.5f);
            _TARGET = FOOD[ew];
            Coordinates.transform.position = new Vector2(0.3f, -0.5f);
            ew++;
            if (ew > 4) ew = 0;
            yield return new WaitForSeconds(1f);
            Coordinates.transform.position = new Vector2(0.3f, -0.5f);
        }
    }
    IEnumerator COR_BezierCurves(float duration = 1.0f) //던지기
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
            _TARGET.transform.position = Vector3.Lerp(p4, p5, time);

            time += Time.deltaTime / duration;

            yield return null;
        }
        
    }

    
    public IEnumerator Throw() //던져질 위치 바꾸기
    {
        for (int i = 0; i < 9; i+=2)
        {
            _p2 = transforms[i];
            _p3 = transforms[i+1];
            StartCoroutine(COR_BezierCurves());
            yield return new WaitForSeconds(2f);
        }
    }
}
