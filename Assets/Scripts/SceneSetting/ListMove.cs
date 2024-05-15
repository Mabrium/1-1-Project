using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListMove : MonoBehaviour
{
    private RectTransform rectTransform;
    private int X = 400;
    private int Y = -400;

    private Vector2 target;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //target = new Vector2(X, Y);
    }
    void Update()
    {
        UpDownHandle();
    }
    private void UpDownHandle()
    {
        
        if(Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
        {
            Up();
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
        {
            Down();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Map");
        }
    }
    private void Up()
    {
        X += -200;
        Y += 200;
        rectTransform.localPosition = new Vector2 (X, Y)/*MoveTowards(rectTransform.position, target, Time.deltaTime)*/;
    }
    private void Down()
    {
        X += 200;
        Y += -200;
        rectTransform.localPosition = new Vector2 (X, Y)/*MoveTowards(rectTransform.position, target, Time.deltaTime)*/;
    }
}
