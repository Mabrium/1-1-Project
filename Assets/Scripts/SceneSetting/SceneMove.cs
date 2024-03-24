using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public FadeInOut fade; //�ٸ� �ڵ� ��������

    public GameObject Setting;
    public GameObject Move;
    private RectTransform rectTransform;

    private bool UpDown = false; //����â �ö���°� Ȯ��
    private bool Moving = false; //����â �����̴°� Ȯ��
    private bool Settinging = false; //����â�� �ö�����ִ� �������� Ȯ��

    private int Xvalue = 0; //����â�� �����̴� ��ġ ��
    private int Yvalue = -1100; //����â�� �����̴� ��ġ��

    private int MoveX = 0; //����â�� ���������� ���õ� ��

    private int MoveXvalue = 0; //����â�� ���������ϴ� ��ġ��
    private int MoveYvalue1 = 0; //����â�� �ö�;��� ��ġ ��
    private int MoveYvalue2 = -1100; //����â�� �����;��� ��ġ ��

    private int XMoveSpeed = 5; //����â �����̴� �ӵ�
    private int YMoveSpeed = 7; //����â �ø��� ������ �ӵ�


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

    IEnumerator MoveScene() //��ŸƮ�� ���õ� �װ� �̵��ϴ� �ڵ� ����â �ø��°ű��� ���� �Ǿ�����
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
