using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneMove : MonoBehaviour
{
    
    public FadeInOut fade;
    public AllSceneChange ASC;
    public StartingSound SS;

    public GameObject Setting;
    public GameObject Credit;
    public GameObject Move;
    public GameObject End;
    private RectTransform rectTransform;
    private RectTransform settingY;
    private RectTransform creditY;

    private bool UpDown = false;     //세팅창 올라오는거 확인
    private bool CUpDown = true;     //크래딧 창 올라오는거 확인
    public bool Moving = false;     //선택창 움직이는거 확인
    public bool Settinging = false; //세팅창이 올라와져있는 상태인지 확인
    private bool GameEnd = false;    //게임을 끝낼건지 창 띄우는거 확인

    private float Xvalue = 0;        //선택창이 움직이는 위치 값
    private float Yvalue = -1100;    //세팅창이 움직이는 위치값
    private float CYvalue = 1100;    //크레딧창이 움직이는 위치값

    public int MoveX = 0;            //선택창이 움직였을때 선택된 값

    private int MoveXvalue = 0;      //선택창이 움직여야하는 위치값
    private int MoveYvalue1 = 0;     //세팅창이 올라와야할 위치 값
    private int MoveYvalue2 = -1100; //세팅창이 내려와야할 위치 값
    private int MoveCYvalue3 = 1100; //크레딧창이 올라가야할 위치값

    [SerializeField]
    private int XMoveSpeed = 30;     //선택창 움직이는 속도
    private int YMoveSpeed = 300;    //세팅창 올리고 내리는 속도


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        settingY = Setting.GetComponent<RectTransform>();
        creditY = Credit.GetComponent<RectTransform>();
    }

    private void Start()
    {
        CUpDown = true;
        UpDown = false;
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

        while (Xvalue > MoveXvalue)
        {
            Xvalue -= XMoveSpeed * Time.deltaTime * 2;
            rectTransform.anchoredPosition = new Vector2(Xvalue, 0);
            yield return Time.deltaTime;
        }
        Moving = false;
    }
    IEnumerator MoveScrollLeft()
    {
        Moving = true;

        while (Xvalue < MoveXvalue)
        {
            Xvalue += XMoveSpeed * Time.deltaTime * 2;
            rectTransform.anchoredPosition = new Vector2(Xvalue, 0);
            yield return Time.deltaTime;
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
        CUpDown = true;
    }
    IEnumerator CreditMoveYDown()
    {
        while (CYvalue >= MoveYvalue1)
        {
            CYvalue -= YMoveSpeed * Time.deltaTime * 10;
            creditY.anchoredPosition = new Vector2(0, CYvalue);
            yield return null;
        }
        CUpDown = false;
    }
    private void MoveScene() //스타트나 세팅등 그거 이동하는 코드 | 세팅창 올리는거까지 포함 되어있음
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchMoveX();
        }
        if (!Settinging)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                ScrollRight();
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ScrollLeft();
            }
        }

        if(GameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameEnd = false;
                End.SetActive(false);
            }
        }
    }

    public void ScrollLeft()
    {
        if (MoveX > 0)
        {
            MoveX--;
            MoveXvalue += 1500;
            StartCoroutine(MoveScrollLeft());
        }
    }

    public void ScrollRight()
    {
        if (MoveX < 4)
        {
            MoveX++;
            MoveXvalue -= 1500;
            StartCoroutine(MoveScrollRight());
        }
    }

    public void switchMoveX()
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
                    SS.StartSound();
                    AudioChange.instance.LoadSound();
                }
                break;
            case 2:
                Moving = true;
                fade.Fade();
                Invoke("LoadSceneTutorial", 2.0f);
                break;
            case 3:
                End.SetActive(true);
                GameEnd = true;
                break;
            case 4:
                if (!CUpDown)
                {
                    Settinging = false;
                    StartCoroutine(CreditMoveYUp());
                }
                if (CUpDown)
                {
                    Settinging = true;
                    StartCoroutine(CreditMoveYDown());
                }
                break;
        }
    }

    public void GEnd()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void GNotEnd()
    {
        GameEnd = false;
        End.SetActive(false);
    }

    public void LoadSceneMap()
    {
        ASC.Library();
    }

    public void LoadSceneTutorial()
    {
        ASC.tutorialScene();
    }
}
