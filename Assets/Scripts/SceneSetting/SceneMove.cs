using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public SoundVolumeChange SVC; //사운드 설정 코드 가져오기
    public FadeInOut fade; //다른 코드 가져오기

    public GameObject Setting;
    public GameObject Move;
    private RectTransform rectTransform;
    private RectTransform settingY;

    private bool UpDown = false; //세팅창 올라오는거 확인
    private bool Moving = false; //선택창 움직이는거 확인
    private bool Settinging = false; //세팅창이 올라와져있는 상태인지 확인

    private float Xvalue = 0; //선택창이 움직이는 위치 값
    private float Yvalue = -1100; //세팅창이 움직이는 위치값

    private int MoveX = 0; //선택창이 움직였을때 선택된 값

    private int MoveXvalue = 0; //선택창이 움직여야하는 위치값
    private int MoveYvalue1 = 0; //세팅창이 올라와야할 위치 값
    private int MoveYvalue2 = -1100; //세팅창이 내려와야할 위치 값

    [SerializeField]
    private int XMoveSpeed = 6; //선택창 움직이는 속도
    private int YMoveSpeed = 170; //세팅창 올리고 내리는 속도


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        settingY = Setting.GetComponent<RectTransform>();
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
            Xvalue -= XMoveSpeed * Time.deltaTime;
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

            Xvalue += XMoveSpeed * Time.deltaTime;
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

    private void MoveScene() //스타트나 세팅등 그거 이동하는 코드 세팅창 올리는거까지 포함 되어있음
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
                        else
                        {
                            if (UpDown)
                            {
                                if(Input.GetKeyDown(KeyCode.Escape))
                                {
                                    Settinging = false;
                                    StartCoroutine(MoveY_Down());
                                    SVC.Save();
                                }
                               
                            }
                        }
                        break;
                    case 4:
                        Application.Quit(); break;

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

    private void LoadSceneMap()
    {
        SceneManager.LoadScene("Map");
    }
}
