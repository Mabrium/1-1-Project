using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarT : MonoBehaviour
{
    void Start()
    {
        Invoke("Scene", 5f);
    }

    private void Scene()
    {
        SceneManager.LoadScene("Starting");
    }
}
