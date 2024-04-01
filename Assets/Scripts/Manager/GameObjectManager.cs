using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
