using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneMove : MonoBehaviour
{
    public SoundVolumeChange SVC;
    public FadeInOut fade;
    public AllSceneChange ASC;

    public GameObject Setting;
    public GameObject Credit;
    public GameObject Move;
    private RectTransform rectTransform;
    private RectTransform settingY;
    private RectTransform creditY;

    private bool UpDown = false; //����â �ö���°� Ȯ��
    private bool Moving = false; //����â �����̴°� Ȯ��
    private bool Settinging = false; //����â�� �ö�����ִ� �������� Ȯ��

    private float Xvalue = 0; //����â�� �����̴� ��ġ ��
    private float Yvalue = -1100; //����â�� �����̴� ��ġ��
    private float CYvalue = 1100;

    private int MoveX = 0; //����â�� ���������� ���õ� ��

    private int MoveXvalue = 0; //����â�� ���������ϴ� ��ġ��
    private int MoveYvalue1 = 0; //����â�� �ö�;��� ��ġ ��
    private int MoveYvalue2 = -1100; //����â�� �����;��� ��ġ ��
    private int MoveCYvalue3 = 1100;

    [SerializeField]
    private int XMoveSpeed = 30; //����â �����̴� �ӵ�
    private int YMoveSpeed = 300; //����â �ø��� ������ �ӵ�


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        settingY = Setting.GetComponent<RectTransform>();
        creditY = Credit.GetComponent<RectTransform>();
    }

    private void Start()
    {
        Moving = true;
        StartCoroutine(StartScene());
    }


    void Update()
    {
        if (!Moving)
        {
            MoveScene();
        }
    }
    private IEnumerator StartScene()
    {
        yield return new WaitForSeconds(2.5f);
        Moving = false;
    }
    IEnumerator MoveScrollRight()
    {
        Moving = true;

        while (Xvalue >= MoveXvalue)
        {
            Xvalue -= XMoveSpeed * Time.deltaTime * 2;
            rectTransform.anchoredPosition = new Vector2(Xvalue, 0);
            yield return null;
        }
        Moving = false;
    }
    IEnumerator MoveScrollLeft()
    {
        Moving = true;

        while (Xvalue <= MoveXvalue)
        {

            Xvalue += XMoveSpeed * Time.deltaTime * 2;
            rectTransform.anchoredPosition = new Vector2(Xvalue, 0);
            yield return null;
        }
        Moving = false;
    }
    IEnumerator MoveY_Up()
    {
        while (Yvalue <= MoveYvalue1)
        {
            Yvalue += YMoveSpeed * Time.deltaTime * 10;
            settingY.anchoredPosition = new Vector2(0, Yvalue);
            yield return null;
        }
        UpDown = true;
    }
    IEnumerator MoveY_Down()
    {
        while (Yvalue >= MoveYvalue2)
        {
            Yvalue -= YMoveSpeed * Time.deltaTime * 10;
            settingY.anchoredPosition = new Vector2(0, Yvalue);
            yield return null;
        }
        UpDown = false;
    }
    IEnumerator CreditMoveYUp()
    {
        while (CYvalue <= MoveCYvalue3)
        {
            CYvalue += YMoveSpeed * Time.deltaTime * 10;
            creditY.anchoredPosition = new Vector2(0, CYvalue);
            yield return null;
        }
        UpDown = true;
    }
    IEnumerator CreditMoveYDown()
    {
        while (CYvalue >= MoveYvalue1)
        {
            CYvalue -= YMoveSpeed * Time.deltaTime * 10;
            creditY.anchoredPosition = new Vector2(0, CYvalue);
            yield return null;
        }
        UpDown = false;
    }
    private void MoveScene() //��ŸƮ�� ���õ� �װ� �̵��ϴ� �ڵ� ����â �ø��°ű��� ���� �Ǿ�����
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switch (MoveX)
                {
                    case 0:
                        Moving = true;
                        fade.Fade();
                        Invoke(nameof(LoadSceneMap), 2.0f);
                        break;
                    case 1:
                        if (!UpDown)
                        {
                            Settinging = true;
                            StartCoroutine(MoveY_Up());
                        }
                        if (UpDown)
                        {
                            Settinging = false;
                            StartCoroutine(MoveY_Down());
                            SVC.Save();
                        }
                        break;
                    case 2:
                        Moving = true;
                        fade.Fade();
                        Invoke(nameof(LoadSceneTutorial), 2.0f);
                        break;
                    case 3:
                        Application.Quit(); break;
                    case 4:
                        if (!UpDown)
                        {
                            Settinging = false;
                            StartCoroutine(CreditMoveYUp());
                        }
                        if (UpDown)
                        {
                            Settinging = true;
                            StartCoroutine(CreditMoveYDown());
                        }
                        break;

                }
            }
            if (!Settinging)
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (MoveX < 4)
                    {
                        MoveX++;
                        MoveXvalue -= 1500;
                        StartCoroutine(MoveScrollRight());
                    }
                }
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (MoveX > 0)
                    {
                        MoveX--;
                        MoveXvalue += 1500;
                        StartCoroutine(MoveScrollLeft());
                    }
                }
            }
    }

    public void LoadSceneMap()
    {
        ASC.Library();
    }

    private void LoadSceneTutorial()
    {
        ASC.tutorialScene();
    }
}
