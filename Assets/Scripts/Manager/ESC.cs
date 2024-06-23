using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour
{
    public AllSceneChange ASC;
    public GameObject ESCWindow;
    private bool esc_on;

    void Start()
    {
        esc_on = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
            
        }
    }

    public void Esc()
    {
        if (!esc_on)
        {
            esc_on = true;
            ESCWindow.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            esc_on = false;
            ESCWindow.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Setting()
    {

    }

    public void Exit()
    {
        ASC.menuScene();
    }
}
