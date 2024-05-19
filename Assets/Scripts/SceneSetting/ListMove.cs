using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListMove : MonoBehaviour
{
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
        UpDownHandle();
    }
    private void UpDownHandle()
    {
        if(Y < 400)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
            {
                Down();
                a++;
                MusicNameList[a].gameObject.SetActive(true);
                MusicNameList[a - 1].gameObject.SetActive(false);
            }
        }
        if(Y > -400)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
            {
                Up();
                a--;
                MusicNameList[a].gameObject.SetActive(true);
                MusicNameList[a + 1].gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Map");
        }
    }
    private void Down()
    {
        X += -200;
        Y += 200;
        rectTransform.localPosition = new Vector2 (X, Y);
    }
    private void Up()
    {
        X += 200;
        Y += -200;
        rectTransform.localPosition = new Vector2 (X, Y);
    }

    
    
}
