using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public static GameObjectManager instance;
    void Awake()
    {
        var obj = FindObjectsOfType<GameObjectManager>();
        DontDestroyOnLoad(gameObject);
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {

            Destroy(gameObject);
        }
    }
}
