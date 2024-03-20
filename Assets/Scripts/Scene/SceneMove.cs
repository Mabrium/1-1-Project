using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public GameObject Setting;
    private int Xvalue = 0;
    private int Yvalue = -1100;
    private bool UpDown = false;
    public int MoveX = 0;
    public int MoveXvalue = 0;
    public int MoveYvalue1 = 0;
    public int MoveYvalue2 = -1100;
    public bool Moving = false;
    public GameObject Move;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Moving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                switch (MoveX)
                {
                    case 0:
                        SceneManager.LoadScene("Start"); break;
                    case 1:
                        if (!UpDown)
                        {
                            StartCoroutine(MoveY_Up());
                        }
                        else StartCoroutine(MoveY_Down());
                        break;
                    case 2:
                        Application.Quit(); break;

                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (MoveX < 2)
                {
                    MoveX++;
                    if (MoveX == 0) MoveXvalue = 0;
                    if (MoveX == 1) MoveXvalue = -1500;
                    if (MoveX == 2) MoveXvalue = -3000;
                    StartCoroutine(MoveScrollRight());
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if(MoveX > 0) 
                {
                    MoveX--;
                    if (MoveX == 0) MoveXvalue = 0;
                    if (MoveX == 1) MoveXvalue = -1500;
                    if (MoveX == 2) MoveXvalue = -3000;
                    StartCoroutine(MoveScrollLeft());
                }
            }
        }
    }

    IEnumerator MoveScrollRight()
    {
            Moving = true;
            
            while (Xvalue >= MoveXvalue)
            {
                rectTransform.anchoredPosition = new Vector2(Xvalue, 0);
                yield return null;
                Xvalue -= 10;
            }
            Moving = false;
    }
    IEnumerator MoveScrollLeft()
    {
        Moving = true;

        while (Xvalue <= MoveXvalue)
        {
            rectTransform.anchoredPosition = new Vector2(Xvalue, 0);
            yield return null;
            Xvalue += 10;
        }
        Moving = false;
    }
    IEnumerator MoveY_Up()
    {
        while (Yvalue <= MoveYvalue1)
        {
            Setting.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Yvalue);
            yield return null;
            Yvalue += 10;
        }
        UpDown = true;
    }
    IEnumerator MoveY_Down()
    {
        while (Yvalue >= MoveYvalue2)
        {
            Setting.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Yvalue);
            yield return null;
            Yvalue -= 10;
        }
        UpDown = false;
    }
}
