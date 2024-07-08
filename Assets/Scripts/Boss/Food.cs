using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject TARGET;
    public SpriteRenderer s;
    public Sprite[] FOOD;
    public Transform _p1, _p2, _p3;
    public Transform[] transforms;
    public Collider2D[] Fooood;

    public float _duration;

    private int ew = 0;
    private int sw = 4;

    private int randomV;
    private int random;

    void Start()
    {
        ew = 0;
        sw = 4;
    }

    public IEnumerator TThrow()
    {
        while (true)
        {
            s.sprite = FOOD[ew];
            Fooood[ew].enabled = true;
            ew++;
            sw++;
            if (ew > 4) ew = 0;
            if (sw > 4) sw = 0;
            yield return new WaitForSeconds(0.995f);
            Fooood[sw].enabled = false;
        }
    }
    public IEnumerator TTThrow()
    {
        while (true)
        {
            s.sprite = FOOD[ew];
            Fooood[ew].enabled = true;
            ew++;
            sw++;
            if (ew > 4) ew = 0;
            if (sw > 4) sw = 0;
            yield return new WaitForSeconds(0.995f);
            Fooood[sw].enabled = false;
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
            TARGET.transform.position = Vector3.Lerp(p4, p5, time);

            time += Time.deltaTime / duration;

            yield return null;
        }
        
    }

    
    public IEnumerator Throw() //던져질 위치 바꾸기
    {
        for (int i = 0; i < 9; i+=2)
        {
            randomV = Random.Range(0, 10);
            if(randomV == 0) { random = 0; }
            if(randomV == 1) { random = 0; }
            if(randomV == 2) { random = 2; }
            if(randomV == 3) { random = 2; }
            if(randomV == 4) { random = 4; }
            if(randomV == 5) { random = 4; }
            if(randomV == 6) { random = 6; }
            if(randomV == 7) { random = 6; }
            if(randomV == 8) { random = 8; }
            if(randomV == 9) { random = 8; }

            _p2 = transforms[random];
            _p3 = transforms[random + 1];
            StartCoroutine(COR_BezierCurves());
            yield return new WaitForSeconds(2f);
        }
    }
}
