using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestSceneChange1 : MonoBehaviour
{
    public GameManager gamemanager;
    // Start is called before the first frame update
    
    public void mapScene()
    {
        SceneManager.LoadScene("Map");
        gamemanager.SaveData();
    }
    public void startingScene()
    {
        SceneManager.LoadScene("Starting");
        gamemanager.SaveData();
    }
    public void testScene()
    {
        SceneManager.LoadScene("Test");
        gamemanager.SaveData();
    }
    public void tutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
        gamemanager.SaveData();
    }
    public void menuScene()
    {
        SceneManager.LoadScene("Menu");
        gamemanager.SaveData();
    }
}
