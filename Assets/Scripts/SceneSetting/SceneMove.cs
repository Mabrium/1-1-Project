using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public FadeInOut fade; //다른 코드 가져오기

    public GameObject Setting;
    public GameObject Move;
    private RectTransform rectTransform;

    private bool UpDown = false; //세팅창 올라오는거 확인
    private bool Moving = false; //선택창 움직이는거 확인
    private bool Settinging = false; //세팅창이 올라와져있는 상태인지 확인

    private int Xvalue = 0; //선택창이 움직이는 위치 값
    private int Yvalue = -1100; //세팅창이 움직이는 위치값

    private int MoveX = 0; //선택창이 움직였을때 선택된 값

    private int MoveXvalue = 0; //선택창이 움직여야하는 위치값
    private int MoveYvalue1 = 0; //세팅창이 올라와야할 위치 값
    private int MoveYvalue2 = -1100; //세팅창이 내려와야할 위치 값

    private int XMoveSpeed = 5; //선택창 움직이는 속도
    private int YMoveSpeed = 7; //세팅창 올리고 내리는 속도


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    


    void Update()
    {
        StartCoroutine(MoveScene());
    }

    IEnumerator MoveScrollRight()
    {
            Moving = true;
            
            while (Xvalue >= MoveXvalue)
            {
                rectTransform.anchoredPosition = new Vector2(Xvalue, 0);
                yield return null;
                Xvalue -= XMoveSpeed;
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
            Xvalue += XMoveSpeed;
        }
        Moving = false;
    }
    IEnumerator MoveY_Up()
    {
        while (Yvalue <= MoveYvalue1)
        {
            Setting.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Yvalue);
            yield return null;
            Yvalue += YMoveSpeed;
        }
        UpDown = true;
    }
    IEnumerator MoveY_Down()
    {
        while (Yvalue >= MoveYvalue2)
        {
            Setting.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Yvalue);
            yield return null;
            Yvalue -= YMoveSpeed;
        }
        UpDown = false;
    }

    IEnumerator MoveScene() //스타트나 세팅등 그거 이동하는 코드 세팅창 올리는거까지 포함 되어있음
    {
        if (!Moving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                switch (MoveX)
                {
                    case 0:
                        Moving = true;
                        fade.Fade();
                        yield return new WaitForSeconds(2.0f);
                        SceneManager.LoadScene("GameStart");
                        break;
                    case 1:

                        if (!UpDown)
                        {
                            Settinging = true;
                            StartCoroutine(MoveY_Up());
                        }
                        else
                        {
                            Settinging = false;
                            StartCoroutine(MoveY_Down());
                        }
                        break;
                    case 2:
                        Application.Quit(); break;

                }
            }
            if (!Settinging)
            {
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
                    if (MoveX > 0)
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
    }
}
