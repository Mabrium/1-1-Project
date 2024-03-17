using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public Setting Setting;
    private int Xvalue = 0;
    public int MoveX = 0;
    public int MoveXvlaue = 0;
    public bool Moving = false;
    public GameObject Move;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        Setting = GetComponent<Setting>();
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
                        break;

                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (MoveX < 2)
                {
                    MoveX++;
                    if (MoveX == 0) MoveXvlaue = 0;
                    if (MoveX == 1) MoveXvlaue = -1500;
                    if (MoveX == 2) MoveXvlaue = -3000;
                    StartCoroutine(MoveScrollRight());
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if(MoveX > 0) 
                {
                    MoveX--;
                    if (MoveX == 0) MoveXvlaue = 0;
                    if (MoveX == 1) MoveXvlaue = -1500;
                    if (MoveX == 2) MoveXvlaue = -3000;
                    StartCoroutine(MoveScrollLeft());
                }
            }
        }
    }

    IEnumerator MoveScrollRight()
    {
            Moving = true;
            
            while (Xvalue >= MoveXvlaue)
            {
                rectTransform.anchoredPosition = new Vector3(Xvalue, 0, 0);
                yield return null;
                Xvalue -= 5;
            }
            Moving = false;
    }
    IEnumerator MoveScrollLeft()
    {
        Moving = true;

        while (Xvalue <= MoveXvlaue)
        {
            rectTransform.anchoredPosition = new Vector3(Xvalue, 0, 0);
            yield return null;
            Xvalue += 5;
        }
        Moving = false;
    }
}
