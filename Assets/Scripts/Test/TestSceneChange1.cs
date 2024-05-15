using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestSceneChange1 : MonoBehaviour
{
    public void mapScene()
    {
        SceneManager.LoadScene("Map");
    }
    public void startingScene()
    {
        SceneManager.LoadScene("Starting");
    }
    public void testScene()
    {
        SceneManager.LoadScene("Test");
    }
    public void tutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void menuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Library()
    {
        SceneManager.LoadScene("Library");
    }
}
