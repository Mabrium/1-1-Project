using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComebackMenu : MonoBehaviour
{
    public void Library()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Library");

    }

    public void ReturnMap()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Boss");
    }

    public void ReturnMap1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Map1");
    }
}
