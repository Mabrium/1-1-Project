using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestSceneChange1 : MonoBehaviour
{
    // Start is called before the first frame update
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
}
