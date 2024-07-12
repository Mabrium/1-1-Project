using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPoint : MonoBehaviour
{
    public Transform[] PointX;
    public Transform[] PointY;

    [SerializeField] private int x;
    [SerializeField] private int y;

    public int patten;

    public bool ShotOk1 = false;
    public bool ShotOk2 = false;
    public bool ShotOk3 = false;

    void Start()
    {
        patten = 10;
        StartCoroutine(startwait());
    }


    private IEnumerator startwait()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(PointChange());
    }
    public IEnumerator PointChange()
    {
        switch (patten)
        {
            case 0:
                print("실행1");
                while (ShotOk1)
                {
                    XPoint();
                    x++;
                    if (x > 1) x = 0;
                    yield return new WaitForSeconds(1f);
                    YPoint();
                    y++;
                    if (y > 1) y = 0;
                    yield return new WaitForSeconds(1f);
                }
                break;
            case 1:
                print("실행2");
                while (ShotOk2)
                {
                    XPoint();
                    YPoint();
                    y++;
                    x++;
                    if (x > 1) x = 0;
                    if (y > 1) y = 0;
                    yield return new WaitForSeconds(1f);
                }
                break;
            case 2:
                print("실행3");
                while (ShotOk3)
                {
                    XXPoint();
                    YYPoint();
                    yield return new WaitForSeconds(1f);
                }
                break;
        }
        

    }

    private void XPoint()
    {
        PointX[x].gameObject.SetActive(true);
        PointX[x].position = new Vector3(Random.Range(-8, 9), PointX[x].position.y, PointX[x].position.z);
        //print($"{PointX[x].position}");

    }

    private void YPoint()
    {
        PointY[y].gameObject.SetActive(true);
        PointY[y].position = new Vector3(PointY[y].position.x, Random.Range(-4, 5), PointY[y].position.z);
        //print($"{PointY[y].position}");
    }

    private void YYPoint()
    {
        PointY[0].gameObject.SetActive(true);
        PointY[1].gameObject.SetActive(true);
        PointY[0].position = new Vector3(PointY[0].position.x, Random.Range(-4, 5), PointY[0].position.z);
        PointY[1].position = new Vector3(PointY[1].position.x, Random.Range(-4, 5), PointY[1].position.z);
    }

    private void XXPoint()
    {
        PointX[0].gameObject.SetActive(true);
        PointX[1].gameObject.SetActive(true);
        PointX[0].position = new Vector3(Random.Range(-8, 9), PointX[0].position.y, PointX[0].position.z);
        PointX[1].position = new Vector3(Random.Range(-8, 9), PointX[1].position.y, PointX[1].position.z);
    }
}
