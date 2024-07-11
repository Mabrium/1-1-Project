using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPoint : MonoBehaviour
{
    public Transform[] PointX;
    public Transform[] PointY;

    [SerializeField] private int x;
    [SerializeField] private int y;

    public bool ShotOk;
    void Start()
    {
        StartCoroutine(PointChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PointChange()
    {
        while (ShotOk)
        {
            XPoint();
            x++;
            if (x > 1) x = 0;
            yield return new WaitForSeconds(0.7f);
            YPoint();
            y++;
            if (y > 1) y = 0;
            yield return new WaitForSeconds(0.7f);

        }

    }

    private void XPoint()
    {
        PointX[x].gameObject.SetActive(true);
        PointX[x].position = new Vector3(Random.Range(-8, 9), PointX[x].position.y, PointX[x].position.z);
        print($"{PointX[x].position}");

    }

    private void YPoint()
    {
        PointY[y].gameObject.SetActive(true);
        PointY[y].position = new Vector3(PointY[y].position.x, Random.Range(-4, 5), PointY[y].position.z);
        print($"{PointY[y].position}");
    }
}
