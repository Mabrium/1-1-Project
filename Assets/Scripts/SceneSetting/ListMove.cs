using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListMove : MonoBehaviour
{
    public CameraSS CS;

    public GameObject[] MusicNameList;
    
    private RectTransform rectTransform;
    private int X = 400;
    private int Y = -400;
    private int a = 0;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (a)
            {
                case 0:
                    SceneManager.LoadScene("Tutorial");
                    break;
                case 1:
                    SceneManager.LoadScene("Boss");
                    break;
                case 2:
                    StartCoroutine(CS.Shake(0.1f, 0.3f));
                    break;
                case 3:
                    StartCoroutine(CS.Shake(0.1f, 0.3f));
                    break;
                case 4:
                    StartCoroutine(CS.Shake(0.1f, 0.3f));
                    break;
            }
        }
        
        UpDownHandle();
    }
    private void UpDownHandle() //방향키나 WASD이용해서 리스트 창 이동
    {
        if(Y < 400)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
            {
                Down();
                MusicNameList[a].gameObject.SetActive(true);
                MusicNameList[a - 1].gameObject.SetActive(false);
            }
        }
        if(Y > -400)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
            {
                Up();
                MusicNameList[a].gameObject.SetActive(true);
                MusicNameList[a + 1].gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    private void Down() //정해진 값대로 이동시켜서 깔끔한 처리
    {
        X += -200;
        Y += 200;
        a++;
        rectTransform.localPosition = new Vector2 (X, Y);
    }
    private void Up()
    {
        X += 200;
        Y += -200;
        a--;
        rectTransform.localPosition = new Vector2 (X, Y);
    }

    
    
}
